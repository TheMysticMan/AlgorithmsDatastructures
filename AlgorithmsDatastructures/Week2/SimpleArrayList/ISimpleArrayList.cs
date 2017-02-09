namespace SimpleArrayList
{
    public interface ISimpleArrayList<T>
    {
        void Add(T n); // toevoegen aan het einde van de lijst, mits de lijst niet vol is
        T Get(uint index); // haal de waarde op van een bepaalde index
        void Set(uint index, T n); // wijzig een item op een bepaalde index
        string ToString(); // print de inhoud van de list
        void Clear(); // maak de list leeg
        int CountOccurences(T n); // tel hoe vaak het gegeven getal voorkomt
    }
}