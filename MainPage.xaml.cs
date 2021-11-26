using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace task__6
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            AddAboba();
        }

        /// <summary>
        /// Поле, по-которому определяется цвет доски
        /// </summary>
        int num;

        /// <summary>
        /// Поле, которое хранит проверку нужного значения строки 
        /// </summary>
        bool checkIndex_i;
        
        /// <summary>
        /// Поле, которое хранит id кнопок
        /// </summary>
        int id;

        /// <summary>
        /// Поле, которое хранит id шашки
        /// </summary>
        int idСhecker;

        /// <summary>
        /// Поле, которое хранит index строки по i
        /// </summary>
        int checkerIndex_i;

        /// <summary>
        /// Поле, которое хранит index столбца по о
        /// </summary>
        int checkerIndex_j;

        /// <summary>
        /// Поле 1, которое хранит индекс второй половины доски, который является доступным для хода
        /// </summary>
        int avlb_left_top;

        /// <summary>
        /// Поле 2, которое хранит индекс второй половины доски, который является доступным для хода
        /// </summary>
        int avlb_right_top;

        /// <summary>
        /// Поле 1, которое хранит индекс первой половины доски, который является доступным для хода
        /// </summary>
        int avlb_right_down;

        /// <summary>
        /// Поле 2, которое хранит индекс первой половины доски, который является доступным для хода
        /// </summary>
        int avlb_left_down;

        /// <summary>
        /// Активная кнопка
        /// </summary>
        Button btnActive;

        /// <summary>
        /// Массив, который хранит id кнопок с правого края
        /// </summary>
        string[] arrSideRight = new string[8];

        /// <summary>
        /// Массив, который хранит id кнопок с левого края
        /// </summary>
        string[] arrSideLeft = new string[8];

        private void AddAboba() 
        {
            Random side_i = new Random();
            Random side_j = new Random();
            checkerIndex_i = side_i.Next(8);
            checkerIndex_j = side_j.Next(8);

            for (int i = 0; i < 8; i++)
            {
                FlexLayout flexBlock = new FlexLayout();
                flexBlock.Direction = FlexDirection.Row;
                block.Children.Add(flexBlock);

                checkIndex_i = checkerIndex_i == i ? true : false;

                for (int j = 0; j < 8; j++) 
                {
                    Button btn = new Button();
                    btn.Clicked += clickBtn;
                    btn.ClassId = $"{++id}";
                    flexBlock.Children.Add(btn);

                    btn.BackgroundColor = num % 2 == 0 ? Color.FloralWhite : Color.Brown;

                    if (j == 0)
                        arrSideLeft[i] = btn.ClassId;

                    if (j == 7)
                        arrSideRight[i] = btn.ClassId;

                    if (checkerIndex_j == j && checkIndex_i == true)
                    {
                        btn.BackgroundColor = Color.Green;
                        btnActive = btn;
                        idСhecker = Convert.ToInt32(btn.ClassId);
                        checkIndex_i = false;
                    }
                    num++;
                }
                num++;
            }
        }

        /// <summary>
        /// Метод, изменяющий цвет активной кнопки
        /// </summary>
        /// <param name="btn">Аргумент функции, который является активной/нажатой кнопкой</param>
        private void ChangeColorActiveBtn(Button btn) 
        {
            if (btn.BackgroundColor == Color.FloralWhite)
            {
                btnActive.BackgroundColor = Color.FloralWhite;
                btnActive = btn;
            }
            if (btn.BackgroundColor == Color.Brown)
            {
                btnActive.BackgroundColor = Color.Brown;
                btnActive = btn;
            }
            btn.BackgroundColor = Color.Green;
            idСhecker = Convert.ToInt32(btn.ClassId);
        }

        private void clickBtn(object sender, EventArgs args) 
        {
            Button btn = (Button)sender;

            // проверка поля на расположение края
            for (int i = 0; i < arrSideRight.Length; i++)
            {
                if (btnActive.ClassId == arrSideRight[i])
                {
                    avlb_right_down = idСhecker;
                    avlb_left_down = idСhecker + 7;
                    avlb_left_top = idСhecker - 9;
                    avlb_right_top = idСhecker;
                    break;
                }
                else if (btnActive.ClassId == arrSideLeft[i]) 
                {
                    avlb_right_down = idСhecker + 9;
                    avlb_left_down = idСhecker;
                    avlb_left_top = idСhecker;
                    avlb_right_top = idСhecker - 7;
                    break;
                }
                else
                {
                    avlb_right_down = idСhecker + 9;
                    avlb_left_down = idСhecker + 7;
                    avlb_left_top = idСhecker - 9;
                    avlb_right_top = idСhecker - 7;
                }
            }

            if (btn.ClassId == avlb_right_down.ToString())
            {
                ChangeColorActiveBtn(btn);
            }
            if (btn.ClassId == avlb_left_down.ToString())
            {
                ChangeColorActiveBtn(btn);
            }
            if (btn.ClassId == avlb_left_top.ToString())
            {
                ChangeColorActiveBtn(btn);
            }
            if (btn.ClassId == avlb_right_top.ToString())
            {
                ChangeColorActiveBtn(btn);
            }
        }
    }
}
