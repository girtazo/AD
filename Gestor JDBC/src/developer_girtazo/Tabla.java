package developer_girtazo;

import java.sql.Connection;
import java.util.Enumeration;
import java.util.Hashtable;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

public class Tabla {
	
	private Connection conexion;
	private ResultSet Lector;
	private PreparedStatement sentenciaSQL;
	private ArrayList<Campo> campos;
	private ArrayList<Hashtable> valores;
	public String nombre;
	private int nCampos;
	
	public Tabla(String nombre) throws SQLException{
		
		this.nombre = nombre;
		this.campos = new ArrayList<Campo>();
		this.conexion = App.getInstance().getMysqlConnection();

		Lector = ((Statement)conexion.createStatement()).executeQuery("Select * FROM "+nombre+" LIMIT 1");
		
		this.nCampos = Lector.getMetaData().getColumnCount();
		
		for (int campo=1; campo <= nCampos; campo++) {
			
			campos.add(new Campo (
					Lector.getMetaData().getColumnLabel(campo),
					Lector.getType()
					)
			);
			
		}
		
		Lector.close();
		
	}
	
	public ArrayList<Campo> getCampos() {
		
		return this.campos;
		
	}
	
	public ArrayList<Hashtable> listar() throws SQLException {
		
		valores = new ArrayList<Hashtable>();
		
		Lector = ((Statement)conexion.createStatement()).executeQuery("Select * FROM "+nombre);
		
		while (Lector.next()) {
			
			Hashtable<String, Object> tupla = new Hashtable<String, Object>();
			
			for(int campo = 1;campo <= nCampos;campo++){
					
				tupla.put(
						campos.get(campo-1).nombre, 
						Lector.getObject(campo)
						);
			}
			
			valores.add(tupla);
		}
		
		Lector.close();
		
		return this.valores;
	}
	
	public void insertar(Hashtable<String,Object> tupla) throws SQLException{
		
		String sentencia = "INSERT INTO " + nombre + " (";
		
		int nCampo = 0;
		
		Enumeration<String> campo = tupla.keys();
		String valor;
		while(campo.hasMoreElements()){
			
			if( tupla.size() > nCampo ){
				
				sentencia += campo.nextElement()+", ";
				
			} else {
				
				sentencia += campo.nextElement()+") ";
				
			}
		}	
		
		nCampo++;
		
		sentencia += "VALUES (";
		
		
		sentenciaSQL = conexion.prepareStatement("");
		
	}
	
}
