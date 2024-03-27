using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace PonVenueMobile
{
    public class Helper
    {
        //ini perubahan
        public static string Url { get; set; } = "https://venue.apspapua.com";
        //public static string Url { get; set; } = "http://192.168.1.8";
        public static JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

    }

    public class IMageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                return Helper.Url + "/" + value.ToString();
            }
            return string.Empty;
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    //public class MyDatePicker : DatePicker
    //{
    //    private string _format = null;
    //    public static readonly BindableProperty NullableDateProperty = BindableProperty.Create<MyDatePicker, DateTime?>(p => p.NullableDate, null);

    //    public DateTime? NullableDate
    //    {
    //        get { return (DateTime?)GetValue(NullableDateProperty); }
    //        set { SetValue(NullableDateProperty, value); UpdateDate(); }
    //    }

    //    private void UpdateDate()
    //    {
    //        if (NullableDate.HasValue) { if (null != _format) Format = _format; Date = NullableDate.Value; }
    //        else { _format = Format; Format = "pick ..."; }
    //    }

    //    protected override void OnBindingContextChanged()
    //    {
    //        base.OnBindingContextChanged();
    //        UpdateDate();
    //    }

    //    protected override void OnPropertyChanged(string propertyName = null)
    //    {
    //        base.OnPropertyChanged(propertyName);
    //        if (propertyName == "Date") NullableDate = Date;
    //    }
    //}
}
