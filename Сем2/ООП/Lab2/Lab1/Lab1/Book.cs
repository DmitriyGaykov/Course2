using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1;

class Book
{
    public string Type { get; set; }
    public int Size { get; set; }
    public string Title { get; set; }
    public string Mader { get; set; }
    public uint CountLists { get; set; }
    public DateTime DTOfCreating { get; set; }
    public string Authors { get; set; }
    public DateTime DTLoud { get; set; }

    public Book(
        string type,
        int size,
        string title,
        string mader,
        uint countLists,
        DateTime dtOfCreating,
        string authors,
        DateTime dtLoud
        )
    {
        Type = type;
        Size = size;
        Title = title;
        Mader = mader;
        CountLists = countLists;
        DTOfCreating = dtOfCreating;
        Authors = authors;
        DTLoud = dtLoud;
    }

    public Book() { }

    public override string ToString() =>
        $"""
        Type: {Type}
        Size: {Size}
        Title: {Title}
        Mader: {Mader}
        Count lists: {CountLists}
        Date of creating: {DTOfCreating}
        Authors: {Authors}
        Date of loud: {DTLoud}
        """;
}
