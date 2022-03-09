using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

class Sample1
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "Hello World";
        
        Label lb = new Label();
        lb.Text = "ようこそC#へ!";
        lb.Font = new Font(lb.Font.FontFamily, 12);
        lb.Top = 15;
        lb.Parent = fm;           //ラベルをフォームにのせる

        PictureBox pb = new PictureBox();
        Image img = Image.FromFile("Cslogo.png");
        Bitmap imgbmp = new Bitmap(img);
        Image resizedImage = resizeImage(imgbmp, new Size(40, 45)); //画像サイズの変更
        pb.Image = resizedImage;
        pb.Left = lb.Right;
        pb.Parent = fm;
        
    

        Application.Run(fm);
    }
    public static Image resizeImage(Image imgToResize, Size size)
    {
        return (Image)(new Bitmap(imgToResize, size));
    }
}
