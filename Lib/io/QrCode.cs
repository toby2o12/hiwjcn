﻿using Lib.helper;
using Lib.extension;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.Rendering;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using ImageProcessor.Imaging;

namespace Lib.io
{
    /// <summary>
    /// Summary description for QrCode
    /// </summary>
    public class QrCode
    {
        public string Charset { private get; set; }
        public ImageFormat Formart { private get; set; }
        public int? Margin { private get; set; }

        public string _charset { get => this.Charset ?? "UTF-8"; }
        public ImageFormat _formart { get => this.Formart ?? ImageFormat.Png; }
        public int _margin { get => this.Margin ?? 1; }

        /// <summary>
        /// 二维码
        /// </summary>
        public byte[] GetQrCodeBytes(string content, int size = 230)
        {
            content = ConvertHelper.GetString(content);

            var option = new QrCodeEncodingOptions()
            {
                CharacterSet = this._charset,
                DisableECI = true,
                ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.H,
                Width = size,
                Height = size,
                Margin = this._margin
            };

            var writer = new BarcodeWriter()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = option
            };

            //生成bitmap
            using (var bm = writer.Write(content))
            {
                return bm.ToBytes(this._formart);
            }
        }

        /// <summary>
        /// 条码
        /// </summary>
        public byte[] GetBarCodeBytes(string content, int width = 300, int height = 50)
        {
            content = ConvertHelper.GetString(content);

            var options = new QrCodeEncodingOptions()
            {
                CharacterSet = this._charset,
                Width = width,
                Height = height,
                Margin = this._margin,
                // 是否是纯码，如果为 false，则会在图片下方显示数字
                PureBarcode = false,
            };

            var writer = new BarcodeWriter()
            {
                Format = BarcodeFormat.CODE_128,
                Options = options
            };

            using (var bm = writer.Write(content))
            {
                return bm.ToBytes(this._formart);
            }
        }

        /// <summary>
        /// 识别二维码
        /// </summary>
        public string DistinguishQrImage(string img_path) =>
            this.DistinguishQrImage(File.ReadAllBytes(img_path));

        /// <summary>
        /// 识别二维码
        /// </summary>
        public string DistinguishQrImage(byte[] b)
        {
            using (var stream = new MemoryStream(b))
            {
                using (var bm = new Bitmap(stream))
                {
                    var reader = new BarcodeReader();
                    reader.Options = new DecodingOptions()
                    {
                        CharacterSet = this._charset,
                        TryHarder = true
                    };
                    var res = reader.Decode(bm);
                    return res.Text;
                }
            }
        }
    }

    public static class QrCodeExtension
    {

        /// <summary>
        /// 带图标二维码
        /// </summary>
        public static byte[] GetQrCodeWithIconBytes(this QrCode coder, string content, string icon_path, int size = 230)
        {
            if (!File.Exists(icon_path)) { throw new Exception("二维码水印图片不存在"); }
            var bs = coder.GetQrCodeBytes(content, size);

            using (var bm = ConvertHelper.BytesToBitmap(bs))
            {
                using (var g = Graphics.FromImage(bm))
                {
                    using (var logo = Image.FromFile(icon_path))
                    {
                        using (var smallLogo = logo.GetThumbnailImage(bm.Width / 5, bm.Height / 5, null, IntPtr.Zero))
                        {
                            //把压缩后的图片绘制到二维码上
                            g.DrawImage(smallLogo, (bm.Width - smallLogo.Width) / 2, (bm.Height - smallLogo.Height) / 2);
                        }
                    }
                }
                return bm.ToBytes(coder._formart);
            }
        }

        /// <summary>
        /// 添加icon
        /// </summary>
        public static byte[] AddIcon(QrCode coder, byte[] bs, string icon_path)
        {
            using (var bm = ConvertHelper.BytesToBitmap(bs))
            {
                using (var ms = new MemoryStream())
                {
                    using (var imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        using (var iconFactory = new ImageFactory(preserveExifData: true))
                        {
                            var icon = iconFactory.Load(icon_path)
                                .Resize(new Size() { Width = bm.Width / 5, Height = bm.Height / 5 }).Image;

                            var overlay = new ImageLayer()
                            {
                                Image = icon,
                                Position = new Point((bm.Width - icon.Width) / 2, (bm.Height - icon.Height) / 2),
                                Size = new Size(icon.Width, icon.Height)
                            };
                            imageFactory.Load(bm)
                                        .Overlay(overlay)
                                        .Format(new JpegFormat { Quality = 100 })
                                        .Save(ms);
                            return ms.ToArray();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 随机调色
        /// </summary>
        public static byte[] AddRandomHue(QrCode coder, byte[] bs)
        {
            using (var ms = new MemoryStream())
            {
                using (var factory = new ImageFactory(preserveExifData: false))
                {
                    var ran = new Random((int)DateTime.Now.Ticks);

                    factory.Load(bs).Hue(ran.RealNext(360 - 1)).Save(ms);
                }

                return ms.ToArray();
            }
        }
    }
}