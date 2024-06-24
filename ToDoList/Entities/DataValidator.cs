using System;

public class DataValidator
{

    public static bool ValidaData(int anno, int mese, int giorno)
    {
        DateTime oggi = DateTime.Today;

        if (anno < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(anno), "L'anno non può essere negativo.");
        }

        if (anno < oggi.Year)
        {
            throw new ArgumentOutOfRangeException(nameof(anno), "L'anno non può essere minore dell'anno corrente.");
        }

        if (mese < 1 || mese > 12)
        {
            throw new ArgumentOutOfRangeException(nameof(mese), "Il mese deve essere compreso tra 1 e 12.");
        }

        if (anno == oggi.Year && mese < oggi.Month)
        {
            throw new ArgumentOutOfRangeException(nameof(mese), "Il mese non può essere minore del mese corrente.");
        }

        int giorniNelMese = DateTime.DaysInMonth(anno, mese);

        if (giorno < 1 || giorno > giorniNelMese)
        {
            throw new ArgumentOutOfRangeException(nameof(giorno), $"Il giorno deve essere compreso tra 1 e {giorniNelMese}.");
        }

        if (anno == oggi.Year && mese == oggi.Month && giorno < oggi.Day)
        {
            throw new ArgumentOutOfRangeException(nameof(giorno), "Il giorno non può essere minore del giorno corrente.");
        }

        return true;
    }

}

