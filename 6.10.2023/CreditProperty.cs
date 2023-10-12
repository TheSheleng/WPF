using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CreditProperty
{
    class CreditProperty : FrameworkElement
    {
        static FrameworkPropertyMetadata Metadata;

        public static readonly DependencyProperty DataProperty;

        static CreditProperty()
        {
            Metadata = new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(ChangedCallbackMethod), 
                    new CoerceValueCallback(CoerceValueCallBackMethod)
                );

            DataProperty = DependencyProperty.Register(
                    "Data",
                    typeof(double),
                    typeof(CreditProperty),
                    Metadata
                );
        }

        public double Data 
        {
            get { return (double)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        static object CoerceValueCallBackMethod(DependencyObject d, object value)
        {
            return (double)value * 12 * 0.36;
        }

        static void ChangedCallbackMethod(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Application.Current.MainWindow.Title = e.NewValue.ToString();
        }
    }
}
