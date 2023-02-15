using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1;

namespace lab3.History;
public class History
{
    private const int MaxSizeOfHistory = 8;
    private List<Form> history;
    private HashSet<Form> allForms = new();
    private int? index;
    public List<Form> Storage => history;
    public int? Index
    {
        get => index;
        set => index = value;
    }

    public History()
    {
        history = new();
        index = null;
    }
    ~History()
    {
        foreach (var form in allForms)
        {
            try
            {
                form.Close();
            }
            catch { }
        }
    }

    public void Add(Form form)
    {
        history.Add(form);
        allForms.Add(form);

        if(history.Count() > MaxSizeOfHistory)
        {
            history.RemoveAt(0);
        }

        index = history.Count() - 1;
    }

    public Form Next()
    {
        if (index is null || index == history.Count() - 1)
        {
            return null;
        }
        Form form = history[(int)++index];
        return form;
    }

    public Form Prev()
    {
        if (index is null || index == 0)
        {
            return null;
        }

        Form form = history[(int)--index];
        return form;
    }

    public void Reset() => index = history.Count() - 1;
}
