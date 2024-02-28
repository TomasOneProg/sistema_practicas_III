using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class CD_Stock
{
    #region ATRIBUTOS
    private int idStock;
    private string fechaDeVencimiento;
    private int numeroDeLote;
    private int cantidad;
    private int idProveedor; // Agregamos el atributo para el IdProveedor
    private int idProducto; // Agregamos el atributo para el IdProducto
    #endregion

    #region PROPERTIES
    public int IdStock
    {
        get => idStock;
        set { idStock = value; }
    }

    public string FechaDeVencimiento
    {
        get => fechaDeVencimiento;
        set { fechaDeVencimiento = value; }
    }

    public int NumeroDeLote
    {
        get => numeroDeLote;
        set { numeroDeLote = value; }
    }

    public int Cantidad
    {
        get => cantidad;
        set { cantidad = value; }
    }
    public int IdProveedor { get; set; }
    public int IdProducto { get; set; }
    #endregion

    #region METODOS
    public DataTable MostrarStock()
    {
        string sSql = "SELECT * FROM Stock";
        clsEjecutarComando Ejecutar = new clsEjecutarComando();
        return Ejecutar.Ejecutar(sSql);
    }

    public void InsertarStock()
    {
        string sSql = $"INSERT INTO Stock (fechaDeVencimiento, numeroDeLote, cantidad) " +
                      $"VALUES ('{FechaDeVencimiento}', '{NumeroDeLote}', '{cantidad}')";
        Console.WriteLine(sSql);
        clsEjecutarComando Ejecutar = new clsEjecutarComando();
        Ejecutar.Ejecutar(sSql);
    }

    public void ModificarStock()
    {
        string sSql = $"UPDATE Stock SET " +
                      $"fechaDeVencimiento = '{FechaDeVencimiento}', " +
                      $"numeroDeLote = '{NumeroDeLote}' " +
                      $"cantidad = '{cantidad}' " +
                      $"WHERE idStock = {IdStock}";
        Console.WriteLine(sSql);
        clsEjecutarComando Ejecutar = new clsEjecutarComando();
        Ejecutar.Ejecutar(sSql);
    }

    public void EliminarStock()
    {
        string sSql = $"DELETE FROM Stock WHERE idStock = {IdStock}";
        clsEjecutarComando Ejecutar = new clsEjecutarComando();
        Ejecutar.Ejecutar(sSql);
    }

    // Método para obtener los nombres de proveedores desde la base de datos
    public List<string> ObtenerNombresProveedores()
    {
        string sSql = "SELECT nombre FROM Proveedores";
        clsEjecutarComando Ejecutar = new clsEjecutarComando();
        DataTable resultado = Ejecutar.Ejecutar(sSql);

        List<string> nombresProveedores = new List<string>();
        foreach (DataRow row in resultado.Rows)
        {
            nombresProveedores.Add(row["nombre"].ToString());
        }
        return nombresProveedores;
    }

    // Método para obtener los nombres de productos desde la base de datos
    public List<string> ObtenerNombresProductos()
    {
        string sSql = "SELECT nombre FROM Productos";
        clsEjecutarComando Ejecutar = new clsEjecutarComando();
        DataTable resultado = Ejecutar.Ejecutar(sSql);

        List<string> nombresProductos = new List<string>();
        foreach (DataRow row in resultado.Rows)
        {
            nombresProductos.Add(row["nombre"].ToString());
        }
        return nombresProductos;
    }

    // Método para obtener el ID del proveedor a partir del nombre
    public int ObtenerIdProveedor(string nombreProveedor)
    {
        string sSql = $"SELECT idProveedor FROM Proveedores WHERE nombre = '{nombreProveedor}'";
        clsEjecutarComando Ejecutar = new clsEjecutarComando();
        DataTable resultado = Ejecutar.Ejecutar(sSql);

        if (resultado.Rows.Count > 0)
        {
            return Convert.ToInt32(resultado.Rows[0]["idProveedor"]);
        }
        else
        {
            // Manejar el caso de que el proveedor no exista
            return -1; // Por ejemplo, podrías retornar -1 como un valor indicativo de error
        }
    }

    // Método para obtener el ID del producto a partir del nombre
    public int ObtenerIdProducto(string nombreProducto)
    {
        string sSql = $"SELECT idProducto FROM Productos WHERE nombre = '{nombreProducto}'";
        clsEjecutarComando Ejecutar = new clsEjecutarComando();
        DataTable resultado = Ejecutar.Ejecutar(sSql);

        if (resultado.Rows.Count > 0)
        {
            return Convert.ToInt32(resultado.Rows[0]["idProducto"]);
        }
        else
        {
            // Manejar el caso de que el producto no exista
            return -1; // Por ejemplo, podrías retornar -1 como un valor indicativo de error
        }
    }
    #endregion
}
