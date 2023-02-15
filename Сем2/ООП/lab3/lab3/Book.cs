using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab3;

namespace Lab1;

public class Book
{
    [Required(ErrorMessage = "Введите тип")]
    public string Type { get; set; }
    [Required(ErrorMessage = "Введите размер")]
    [Range(1, 3000, ErrorMessage = "Размер в байтах должен быть от 1мб до 3гб")]
    public int Size { get; set; }
    [Required(ErrorMessage = "Введите заголовок")]
    [MinLength(1, ErrorMessage = "Минимальный размер названия должен быть 1 имвол")]
    [MaxLength(50, ErrorMessage = "Максимальный размер названия должен быть 50 символов")]
    [RegularExpression(@"[A-Za-zА-Яа-я0-9]+", ErrorMessage = "Заголовок может состоять только из букв и цифр")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Введите издательство")]
    [MinLength(2, ErrorMessage = "Минимальный размер издательства 2")]
    [MaxLength(50, ErrorMessage = "Максимальный размер издательства 50")]
    public string Mader { get; set; }

    [Range(1, 100000, ErrorMessage = "Количество страниц должно быть от 1 до 100000")]
    [Required (ErrorMessage = "Введите количество листов")]
    public uint CountLists { get; set; }
    [DateFromBefore("1000", "2023", ErrorMessage = "Год создания ограничен от 1000 до 2023")]
    public DateTime DTOfCreating { get; set; }
    public string Authors { get; set; }
    [DateFromBefore("2020", "2023", ErrorMessage = "Год загрузки должен быть от 2020 до 2023")]
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
