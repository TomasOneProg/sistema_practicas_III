using CapaAccesoDatos;
using System;
using System.Data;
using System.Data.SqlClient;

public class CD_Stock
{
    #region ATRIBUTOS
    private int idStock;
    private string fechaDeVencimiento;
    private int numeroDeLote;
    private int cantidad;
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
    #endregion
}
