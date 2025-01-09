using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class CircularProgressBar : Control
{
    private int _progress;
    private Timer _timer;

    // Propriedades customizáveis
    public int TotalTime { get; set; } = 30; // Tempo total em segundos
    public Color ProgressColor { get; set; } = Color.Green;
    public Color BackgroundColor { get; set; } = Color.Gray;
    public int ArcThickness { get; set; } = 6;

    // Evento disparado ao completar o progresso
    public event EventHandler ProgressCompleted;

    public int Progress
    {
        get => _progress;
        set
        {
            _progress = value;
            Invalidate(); // Redesenha o controle
        }
    }

    public CircularProgressBar()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;

        _timer = new Timer();
        _timer.Interval = 100; // Intervalo em milissegundos
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
        // Fundo do arco
        using (Pen backgroundPen = new Pen(BackgroundColor, ArcThickness))
        {
            g.DrawArc(backgroundPen, ArcThickness / 2, ArcThickness / 2, Width - ArcThickness, Height - ArcThickness, 0, 360);
        }

        // Progresso do arco
        float percentage = (float)_progress / (TotalTime * 10); // 10 passos por segundo
        int sweepAngle = (int)(360 * percentage);

        using (Pen progressPen = new Pen(ProgressColor, ArcThickness))
        {
            g.DrawArc(progressPen, ArcThickness / 2, ArcThickness / 2, Width - ArcThickness, Height - ArcThickness, -90, sweepAngle);
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
        if (_progress >= TotalTime * 10) // Multiplica pelo fator de tempo do timer
        {
            _timer.Stop();
            ProgressCompleted?.Invoke(this, EventArgs.Empty); // Dispara o evento de conclusão
        }
        else
        {
            _progress++;
            Invalidate();
        }
    }
}
