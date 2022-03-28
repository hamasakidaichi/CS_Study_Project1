using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

class HelloWorld : Form
{
    private Label lb;
    private Button bt;
    private PictureBox pb;
    private Image img;
    private Bitmap imgbmp;
    private int s;

    public static void Main()
    {
        Application.Run(new HelloWorld());
    }


    public HelloWorld()
    {
        this.Text = "Hello World";
        this.DoubleBuffered = true;

        s = 0;
        Timer tm = new Timer();
        tm.Interval = 100;
        tm.Start();

        lb = new Label();
        lb.Text = "ようこそC#へ!";
        lb.Font = new Font(lb.Font.FontFamily, 12);
        lb.Top = 15;
        

        pb = new PictureBox();
        img = Image.FromFile("Cslogo.png");
        imgbmp = new Bitmap(img);
        Image resizedImage = resizeImage(imgbmp, new Size(40, 45)); //画像サイズの変更
        pb.Image = resizedImage;
        pb.Left = lb.Right;
        

        bt = new Button();
        bt.Text = "押すな！";
        bt.Top = this.Height - 90; bt.Left = this.Width - 120;
        bt.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

        lb.Parent = this;           //ラベルをフォームにのせる
        pb.Parent = this;
        bt.Parent = this;

        this.Paint += new PaintEventHandler(fm_Paint);
        tm.Tick += new EventHandler(tm_Tick);
        bt.Click += new EventHandler(bt_Click);


    }
    public static Image resizeImage(Image imgToResize, Size size)
    {
        return (Image)(new Bitmap(imgToResize, size));
    }

    public void bt_Click(Object sender, EventArgs e)
    {
        MessageBox.Show("なぜ、押したのですか", "Why?");
    }

    public void fm_Paint(Object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        int w = 100;
        int h = 100;

        g.FillEllipse(new SolidBrush(Color.DeepPink), 70, 70, w, h);
        g.FillPie(new SolidBrush(Color.DarkOrchid), 70, 70, w, h, -90, (float)0.6 * s);
        g.FillEllipse(new SolidBrush(Color.Bisque), 95, 95, (int)w / 2, (int)h / 2);

        string time = s / 10 + ":" + s % 10;

        Font f = new Font("Courier", 15);
        SizeF ts = g.MeasureString(time, f);

        g.DrawString(time, f, new SolidBrush(Color.Black), 100, 105);
    }

    public void tm_Tick(Object sender, EventArgs e)
    {
        s = s + 1;
        if (s > 600) s = 0;
        this.Invalidate();
    }

}
