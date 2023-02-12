using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1;

static class ProgressInfo
{
    static private Dictionary<Control, IInfo> controllers = new();
    static private ProgressBar progressBar;

    static public int Maximum { get; private set; }

    static public Dictionary<Control, IInfo> Controllers
    {
        get => controllers;
        set => controllers = value;
    }

    static public ProgressBar ProgressBar
    {
        get => progressBar;
        set 
        { 
            progressBar = value;
            progressBar.Maximum = Controllers.Count();

            Maximum = ProgressBar.Maximum;
        }
    }

    static private int GetCountOfFilledControllers() => controllers.Values.Count(el => el.IsUsed);
    static public int GetProgress() => (int)Math.Round((double)GetCountOfFilledControllers() / (double)controllers.Values.Count() * (double)Maximum);
    static public void SetProgressBarValue() => ProgressBar.Value = GetProgress();
}
