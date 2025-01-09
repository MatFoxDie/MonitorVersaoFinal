using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PainelNoticias.Controls
{
    public class LinearProgressBar : Control
    {
        private int _progress;
        private Timer _timer;

        public int TotalTime { get; set; } = 30; // Tempo total em segundos
        public Color ProgressColor { get; set; } = Color.Red;
        public Color BackgroundColor { get; set; } = Color.Gray;

        public int Progress
        {
            get => _progress;
            set
            {
                _progress = value;
                Invalidate(); // Redesenha o controle
            }
        }

        public LinearProgressBar()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            _timer = new Timer { Interval = 100 }; // Atualização suave
            _timer.Tick += (s, e) =>
            {
                if (_progress >= TotalTime * 10)
                {
                    _timer.Stop();
                    ProgressCompleted?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    _progress++;
                    Invalidate();
                }
            };
        }

        public event EventHandler ProgressCompleted;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var progressWidth = (int)(Width * ((float)_progress / (TotalTime * 10)));
            e.Graphics.Clear(BackgroundColor);

            using (var brush = new SolidBrush(ProgressColor))
                e.Graphics.FillRectangle(brush, 0, 0, progressWidth, Height);
        }

        public void Start() => _timer.Start();

        public void Stop() => _timer.Stop();

        public void Reset()
        {
            _progress = 0;
            Invalidate(); // Redesenha o controle para exibir o reset
        }
    }


}
