namespace _09._02___Produkte
{
    class Menu
    {
        int _margin;
        int _width;

        int _xLeft;
        int _xRight;

        int _yLabelTop;
        int _yContentTop;
        int _yLabelBottom;
        int _yContentBottom;
        int _yPrompt;

        int _maxAnzProdukte;
        Category _activeCategory;
        Category[] _categories;

        public Menu(Category[] categories, int margin, int width)
        {
            _categories = categories;
            _margin = margin;
            _width = width;
            _maxAnzProdukte = GetProcutsMax(_categories);
            _xLeft = _margin;
            _xRight = _margin + _width + _margin;
            _yLabelTop = _margin;
            _yContentTop = _yLabelTop + 1;
            _yLabelBottom = _yContentTop + categories.Length + _margin;
            _yContentBottom = _yLabelBottom + 1;
            _yPrompt = _yContentBottom + _maxAnzProdukte + _margin;
        }

        public void PromptUser()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Black;
            switch (Console.ReadKey().KeyChar.ToString().ToLower().ToCharArray()[0])
            {
                case 'k': Kategoriewahl(); break;
                case 'p': Produktwahl(); break;
                default: break;
            }
        }

        private void Kategoriewahl()
        {
            Console.SetCursorPosition(_xLeft, _yLabelTop);
            Console.Write(new String(' ', _width));
            Console.SetCursorPosition(_xLeft, _yLabelTop);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("Kategorien");
            Console.ResetColor();

            SetCategory(Console.ReadKey().KeyChar - 48 - 1);

            Console.SetCursorPosition(_xLeft, _yLabelTop);
            Console.Write(new String(' ', _width));
            Console.SetCursorPosition(_xLeft, _yLabelTop);
            Console.Write("Kategorien");
        }

        private void Produktwahl()
        {
            Console.SetCursorPosition(_xLeft, _yLabelBottom);
            Console.Write(new String(' ', _width));
            Console.SetCursorPosition(_xLeft, _yLabelBottom);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("Produkte:");
            Console.ResetColor();

            PrintProductDetails(Console.ReadKey().KeyChar - 48 - 1);

            Console.SetCursorPosition(_xLeft, _yLabelBottom);
            Console.Write(new String(' ', _width));
            Console.SetCursorPosition(_xLeft, _yLabelBottom);
            Console.Write("Produkte:");
        }

        public void PrintProducts(int index)
        {
            for (int i = 0; i < _maxAnzProdukte; i++)
            {
                Console.SetCursorPosition(_xLeft, _yContentBottom + i);
                Console.Write(new String(' ', 25));
            }
            for (int i = 0; i < _categories[index].Products.Count; i++)
            {
                Console.SetCursorPosition(_xLeft, _yContentBottom + i);
                Console.Write($"{i + 1}: {_categories[index].Products[i].Name}");
            }
        }

        private void PrintProductDetails(int productIndex)
        {
            if (productIndex >= 0 && productIndex < _activeCategory?.Products.Count)
            {
                Console.SetCursorPosition(_xRight, _yContentTop);
                Console.Write(new String(' ', 25));
                Console.SetCursorPosition(_xRight, _yContentBottom);
                Console.Write(new String(' ', 25));
                Console.SetCursorPosition(_xRight, _yContentTop);
                Console.Write(_activeCategory.Products[productIndex].Name);
                Console.SetCursorPosition(_xRight, _yContentBottom);
                Console.Write($"{_activeCategory.Products[productIndex].Price:C2}");
            }
        }

        private void PrintCategories()
        {
            // Kategorien
            for (int i = 0; i < _categories.Length; i++)
            {
                Console.SetCursorPosition(_xLeft, _yContentTop + i);
                Console.WriteLine($"{i + 1}: {_categories[i].CategoryName}");
            }
        }
        private void PrintCategories(int activeIndex)
        {
            PrintCategories();
            Console.SetCursorPosition(_xLeft, _yContentTop + activeIndex);
            Console.Write(new String(' ', 20));
            Console.SetCursorPosition(_xLeft, _yContentTop + activeIndex);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write($"{activeIndex + 1}: {_categories[activeIndex].CategoryName}");
            Console.ResetColor();
        }

        public void PrintStaticText()
        {

            Console.SetCursorPosition(_xLeft, _yLabelTop);
            Console.Write(new String(' ', _width));
            Console.SetCursorPosition(_xLeft, _yLabelTop);
            Console.Write("Kategorien");

            Console.SetCursorPosition(_xRight, _yLabelTop);
            Console.Write(new String(' ', _width));
            Console.SetCursorPosition(_xRight, _yLabelTop);
            Console.Write("Produktname");

            Console.SetCursorPosition(_xLeft, _yLabelBottom);
            Console.Write(new String(' ', _width));
            Console.SetCursorPosition(_xLeft, _yLabelBottom);
            Console.Write("Produkte");

            Console.SetCursorPosition(_xRight, _yLabelBottom);
            Console.Write(new String(' ', _width));
            Console.SetCursorPosition(_xRight, _yLabelBottom);
            Console.Write("Preis");

            Console.SetCursorPosition(_xLeft, _yPrompt);
            Console.Write("[K]ategorie\t[P]rodukt");

            PrintCategories();
        }

        private int GetProcutsMax(Category[] kategorien)
        {
            int max = 0;
            foreach (Category cat in kategorien)
            {
                if (cat.Products.Count > max) max = cat.Products.Count;
            }
            return max;
        }

        public void SetCategory(int index)
        {
            if (index >= 0 && index < _categories.Length)
            {
                _activeCategory = _categories[index];
                PrintCategories(index);
                PrintProducts(index);
            }
        }
    }
}
