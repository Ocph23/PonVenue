namespace PonVenue;


public class Helper
{

    public static string GetWeekName(DateTime? tanggal)
    {

        if(tanggal==null)
            return " ";
        switch (tanggal.Value.DayOfWeek)
        {
            case DayOfWeek.Sunday:
                return "Minggu";
            case DayOfWeek.Monday:
                return "Senin";
            case DayOfWeek.Thursday:
                return "Selasa";
            case DayOfWeek.Tuesday:
                return "Rabu";
            case DayOfWeek.Wednesday:
                return "Kamis";
            case DayOfWeek.Friday:
                return "Jumat";
            case DayOfWeek.Saturday:
                return "Sabtu";

            default:
                return "Minggu";
        }
    }

}