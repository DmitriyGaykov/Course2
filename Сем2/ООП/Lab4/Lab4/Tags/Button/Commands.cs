using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab4.Tags.Button
{
    public static class Commands
    {
        public static readonly RoutedCommand SayHello = new RoutedUICommand("SayHello", "Say Hello", typeof(Commands));
    }
}
