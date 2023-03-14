﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace projet1
{


    public class CustomTextBox : TextBox
    {
        private string Text_ = "";
        public CustomTextBox() : base()
        { }

        public string setHint
        {
            get { return Text_; }
            set { Text_ = value; }
        }
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            if (Text_.Equals(this.Text))
                this.Clear();
        }
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            if (String.IsNullOrWhiteSpace(this.Text))
                this.Text = Text_;
        }
    }
}
