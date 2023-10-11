namespace jsonApi
{
    public class ComplexFilterItem
    {
        public int IdCategoria { get; set; }
        public int Idsubcategoria { get; set; }
    }

    public class ComplexFilters : List<ComplexFilterItem>
      { }
}
