using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// Summary description for Conexion
/// </summary>
public class Conexion
{
    public Conexion()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static String contring
    {
        get { return ConfigurationManager.ConnectionStrings["Afil-67ConnectionString"].ConnectionString; }
    }

    public static String constringAfil25
    {
        get { return ConfigurationManager.ConnectionStrings["Afil-25ConnecString"].ConnectionString; }
    }
}