﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SmartFridge
{
    /// <summary>
    /// Логика взаимодействия для FridgePage.xaml
    /// </summary>
    public partial class FridgePage : Window
    {
        
        public FridgePage()
        {
            InitializeComponent();
        }
    }
}
/* public partial class FridgePage : Window
    {
        private FridgePage(List<Product> products);
        public FridgePage()
        {
            InitializeComponent();
            Grid.ItemSource = new List<Product>(products);
        }
    }  */
