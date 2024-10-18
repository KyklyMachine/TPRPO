using System;
using System.Windows.Forms;

public class Constants
{
    // символ для перехода к следующей части шаблона
    public const char NEXT_TEMPLATE_PART = ' ';
    public const char WORD = 'w';

    // начало и конец шаблона
    public const char START_TEMPLATE = '[';
    public const char END_TEMPLATE = ']';

    // Повторение шаблона
    public const char MULTIPLE_SYMBOLS_ALLOWED = '+';
    public const char SINGLE_SYMBOL_ALLOWED = '?';

    // добавления пунктуации после ввода части шаблона
    public const char ADD_SPACE = 's';
    public const char ADD_DASH = 'd';
    public const char ADD_POINT = 'p';
    public const char ADD_NONE = 'n';

    // действия с буквами на поднятие клавиши
    public const char TO_LOWER = 'l';
    public const char TO_UPPER = 'u';
    public const char TO_NONE = 'n';

    // массивы с управляющими символами
    public static readonly char[] TEMPLATE_FIRST_PART_SYMBOLS = { WORD };
    public static readonly char[] TEMPLATE_SECOND_PART_SYMBOLS = { TO_LOWER, TO_UPPER, TO_NONE };
    public static readonly char[] TEMPLATE_THIRD_PART_SYMBOLS = { ADD_DASH, ADD_SPACE, ADD_POINT, ADD_NONE };
    public static readonly char[] TEMPLATE_FOURTH_PART_SYMBOLS = { MULTIPLE_SYMBOLS_ALLOWED, SINGLE_SYMBOL_ALLOWED };
    public static readonly char[][] TEMPLATE_PARTS_SYMBOLS = {
        TEMPLATE_FIRST_PART_SYMBOLS,
        TEMPLATE_SECOND_PART_SYMBOLS,
        TEMPLATE_FOURTH_PART_SYMBOLS,
        TEMPLATE_THIRD_PART_SYMBOLS
    };
}
