using System.Data;

public class CN_Menu
{
    private CD_Menu cdMenu = new CD_Menu();

    #region ATRIBUTOS
    private int idMenu;
    private string region;
    private string categoria;
    private int popularidad;
    private float precio;
    private string temporada;
    private string tipoDeEvento;
    private int tiempoPreparacionEstimado;
    private string descripcion;
    #endregion

    #region PROPERTIES
    public int IdMenu
    {
        get => idMenu;
        set { idMenu = value; }
    }

    public string Region
    {
        get => region;
        set { region = value; }
    }

    public string Categoria
    {
        get => categoria;
        set { categoria = value; }
    }

    public int Popularidad
    {
        get => popularidad;
        set { popularidad = value; }
    }

    public float Precio
    {
        get => precio;
        set { precio = value; }
    }

    public string Temporada
    {
        get => temporada;
        set { temporada = value; }
    }

    public string TipoDeEvento
    {
        get => tipoDeEvento;
        set { tipoDeEvento = value; }
    }

    public int TiempoPreparacionEstimado
    {
        get => tiempoPreparacionEstimado;
        set { tiempoPreparacionEstimado = value; }
    }

    public string Descripcion
    {
        get => descripcion;
        set { descripcion = value; }
    }
    #endregion

    #region METODOS
    public DataTable MostrarMenu()
    {
        DataTable tabla = new DataTable();
        tabla = cdMenu.MostrarMenu();
        return tabla;
    }

    public void InsertarMenu()
    {
        PasarDatos();
        cdMenu.InsertarMenu();
    }

    public void ModificarMenu()
    {
        PasarDatos();
        cdMenu.ModificarMenu();
    }

    public void EliminarMenu()
    {
        cdMenu.IdMenu = IdMenu;
        cdMenu.EliminarMenu();
    }

    private void PasarDatos()
    {
        cdMenu.IdMenu = IdMenu;
        cdMenu.Region = Region;
        cdMenu.Categoria = Categoria;
        cdMenu.Popularidad = Popularidad;
        cdMenu.Precio = Precio;
        cdMenu.Temporada = Temporada;
        cdMenu.TipoDeEvento = TipoDeEvento;
        cdMenu.TiempoPreparacionEstimado = TiempoPreparacionEstimado;
        cdMenu.Descripcion = Descripcion;
    }
    #endregion
}
