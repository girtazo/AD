package developer_girtazo;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

public class Tabla
{
	private Connection conexion;
	private ResultSet Lector;
	private PreparedStatement sentenciaSQL;
	private ArrayList<Campo> campos;
	private ArrayList<Object> valores;
	public String nombre;
	public Tabla(String nombre) throws SQLException{
		this.nombre = nombre;
		this.campos = new ArrayList<Campo>();
		this.conexion = App.getInstance().getMysqlConnection();
		Lector = ((Statement)conexion.createStatement()).executeQuery("Select * FROM "+this.nombre+" LIMIT 1");
		for (int campo=0; campo < this.Lector.getRow(); campo++) {
			this.campos.add( new Campo (this.Lector.getString(campo)/*, this.Lector.(campo)*/));
		}
		Lector.close();
	}
	public ArrayList<Campo> getCampos()
	{
		return this.campos;
	}
	public ArrayList<Object> listar() throws SQLException
	{
		this.valores = new ArrayList<Object>();
		int c = 0;
		Lector = ((Statement)conexion.createStatement()).executeQuery("Select * FROM "+nombre);
		while (Lector.next()) {
			ArrayList<String> tupla = new ArrayList<String>();
			for(int campo = 1;campo<=Lector.getMetaData().getColumnCount();campo++){
					tupla.add (Lector.getString(campo));
			}
			this.valores.add(tupla);
		}
		Lector.close();
		return this.valores;
	}
}
