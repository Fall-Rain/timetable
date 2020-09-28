using System.Drawing;

namespace Utity
{
    public class ImageDistinguish
    {
        public string imgName { get; set; }
        private Bitmap bitmap { get; set; }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="img"></param>
        public ImageDistinguish(Bitmap img)
        {
            bitmap = img;
        }
        /// <summary>
        /// 构造图像识别
        /// </summary>
        /// <param name="img"></param>
        public ImageDistinguish(string path)
        {
            bitmap = new Bitmap(path);
            imgName = path;
        }
        /// <summary>
        /// 截图，只截取(0,0)到(400,400)位置的图片，包含了二维码了
        /// </summary>
        /// <returns></returns>
        public ImageDistinguish ScreenShot()
        {
            Bitmap destBitmap = new Bitmap(400, 400);//目标图
            Rectangle destRect = new Rectangle(0, 0, 400, 400);//矩形容器
            Rectangle srcRect = new Rectangle(0, 0, 400, 400);
            Graphics gh = Graphics.FromImage(destBitmap);
            gh.DrawImage(bitmap, destRect, srcRect, GraphicsUnit.Pixel);
            bitmap = destBitmap;
            return this;
        }
        /// <summary>
        /// 二值化处理
        /// </summary>
        /// <returns></returns>
        public ImageDistinguish TwoValued()
        {
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color pixelColor = bitmap.GetPixel(i, j);
                    if (pixelColor.R < 127.5 || pixelColor.G < 127.5 && pixelColor.B < 127.5)
                    {
                        bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        bitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }
                }
            }
            return this;
        }
        public ImageDistinguish TwoValued(int Level)
        {
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color pixelColor = bitmap.GetPixel(i, j);
                    if (pixelColor.R < Level || pixelColor.G < Level && pixelColor.B < Level)
                    {
                        bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        bitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }
                }
            }
            return this;
        }
        /// <summary>
        /// 柔化处理
        /// </summary>
        /// <returns></returns>
        public ImageDistinguish SoftenImage()
        {
            int height = bitmap.Height;
            int width = bitmap.Width;
            Bitmap newbmp = new Bitmap(width, height);
            LockBitmap lbmp = new LockBitmap(bitmap);
            LockBitmap newlbmp = new LockBitmap(newbmp);
            lbmp.LockBits();
            newlbmp.LockBits();

            Color pixel;
            //高斯模板
            int[] Gauss = { 1, 2, 1, 2, 4, 2, 1, 2, 1 };
            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    int r = 0, g = 0, b = 0;
                    int Index = 0;
                    for (int col = -1; col <= 1; col++)
                    {
                        for (int row = -1; row <= 1; row++)
                        {
                            pixel = lbmp.GetPixel(x + row, y + col);
                            r += pixel.R * Gauss[Index];
                            g += pixel.G * Gauss[Index];
                            b += pixel.B * Gauss[Index];
                            Index++;
                        }
                    }
                    r /= 16;
                    g /= 16;
                    b /= 16;
                    //处理颜色值溢出
                    r = r > 255 ? 255 : r;
                    r = r < 0 ? 0 : r;
                    g = g > 255 ? 255 : g;
                    g = g < 0 ? 0 : g;
                    b = b > 255 ? 255 : b;
                    b = b < 0 ? 0 : b;
                    newlbmp.SetPixel(x - 1, y - 1, Color.FromArgb(r, g, b));
                }
            }
            lbmp.UnlockBits();
            newlbmp.UnlockBits();
            bitmap = newbmp;
            return this;
        }

        /// <summary>
        /// 图像锐化处理
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public ImageDistinguish SharpenImage()
        {
            int height = bitmap.Height;
            int width = bitmap.Width;
            Bitmap newbmp = new Bitmap(width, height);

            LockBitmap lbmp = new LockBitmap(bitmap);
            LockBitmap newlbmp = new LockBitmap(newbmp);
            lbmp.LockBits();
            newlbmp.LockBits();

            Color pixel;
            //拉普拉斯模板
            int[] Laplacian = { -1, -1, -1, -1, 9, -1, -1, -1, -1 };
            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    int r = 0, g = 0, b = 0;
                    int Index = 0;
                    for (int col = -1; col <= 1; col++)
                    {
                        for (int row = -1; row <= 1; row++)
                        {
                            pixel = lbmp.GetPixel(x + row, y + col); r += pixel.R * Laplacian[Index];
                            g += pixel.G * Laplacian[Index];
                            b += pixel.B * Laplacian[Index];
                            Index++;
                        }
                    }
                    //处理颜色值溢出
                    r = r > 255 ? 255 : r;
                    r = r < 0 ? 0 : r;
                    g = g > 255 ? 255 : g;
                    g = g < 0 ? 0 : g;
                    b = b > 255 ? 255 : b;
                    b = b < 0 ? 0 : b;
                    newlbmp.SetPixel(x - 1, y - 1, Color.FromArgb(r, g, b));
                }
            }
            lbmp.UnlockBits();
            newlbmp.UnlockBits();
            return this;
        }
        /// <summary>
        /// 获取处理完成后的图片
        /// </summary>
        /// <returns></returns>
        public Bitmap Result()
        {
            return bitmap;
        }
        /// <summary>
        /// 3×3中值滤波除杂，yuanbao,2007.10
        /// </summary>
        /// <param name="dgGrayValue"></param>
        public ImageDistinguish ClearNoise()
        {
            int x, y;
            byte[] p = new byte[9]; //最小处理窗口3*3
            byte s;
            int i, j;
            for (y = 1; y < bitmap.Height - 1; y++) //--第一行和最后一行无法取窗口
            {
                for (x = 1; x < bitmap.Width - 1; x++)
                {
                    //取9个点的值
                    p[0] = bitmap.GetPixel(x - 1, y - 1).R;
                    p[1] = bitmap.GetPixel(x, y - 1).R;
                    p[2] = bitmap.GetPixel(x + 1, y - 1).R;
                    p[3] = bitmap.GetPixel(x - 1, y).R;
                    p[4] = bitmap.GetPixel(x, y).R;
                    p[5] = bitmap.GetPixel(x + 1, y).R;
                    p[6] = bitmap.GetPixel(x - 1, y + 1).R;
                    p[7] = bitmap.GetPixel(x, y + 1).R;
                    p[8] = bitmap.GetPixel(x + 1, y + 1).R;
                    //计算中值
                    for (j = 0; j < 5; j++)
                    {
                        for (i = j + 1; i < 9; i++)
                        {
                            if (p[j] > p[i])
                            {
                                s = p[j];
                                p[j] = p[i];
                                p[i] = s;
                            }
                        }
                    }
                    bitmap.SetPixel(x, y, Color.FromArgb(p[4], p[4], p[4]));    //给有效值付中值
                }
            }
            return this;
        }
    }
}
