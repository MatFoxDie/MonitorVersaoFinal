using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class CircularProgressBar : Control
{
    private int _progress;
    private Timer _timer;

    public int Progress
    {
        get => _progress;
        set
        {
            _progress = value;
            Invalidate();
        }
    }

    public CircularProgressBar()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        _progress = 0;

        _timer = new Timer();
        _timer.Interval = 1000; // 1 second interval
        _timer.Tick += Timer_Tick;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        DrawProgressBar(e.Graphics);
    }

    private void DrawProgressBar(Graphics g)
    {
        float percentage = _progress / 30f; // Assuming a 30 seconds countdown
        int sweepAngle = (int)(360 * percentage);

        using (Pen pen = new Pen(Color.Green, 6))
        {
            g.DrawArc(pen, 3, 3, Width - 6, Height - 6, -90, sweepAngle);
        }
    }

    public void Start()
    {
        _progress = 0;
        _timer.Start();
    }

    public void Stop()
    {
        _timer.Stop();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        if (_progress >= 30)
        {
            _timer.Stop();
        }
        else
        {
            _progress++;
            Invalidate();
        }
    }
}
