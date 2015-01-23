package developer_girtazo;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class App {
	
	private App(){
		
	}
	
	private static App instance = new App();
	public static App getInstance() {
		return instance;
	}
	
	private String servidor = "192.168.24.214";
	public String getServidor (){
		return servidor;
	}
	public void setServidor(String value) throws SQLException{
		this.servidor = value;
		mysqlConnection = DriverManager.getConnection("jdbc:mysql://"+servidor+"/"+baseDatos+"?user="+usuario+"&password="+password);
	}
	
	private String usuario = "root";
	public String getUsuario() {
		return usuario;
	}
	public void setUsuario(String value) throws SQLException{
		this.usuario = value;
		mysqlConnection = DriverManager.getConnection("jdbc:mysql://"+servidor+"/"+baseDatos+"?user="+usuario+"&password="+password);
	}
	
	private String password = "sistemas";
	public String getPassword() {
		return password;
	}
	public void setPassword(String value) throws SQLException{
		this.password = value;
		mysqlConnection = DriverManager.getConnection("jdbc:mysql://"+servidor+"/"+baseDatos+"?user="+usuario+"&password="+password);
	}
	
	private String baseDatos = "dbprueba";
	public String getBaseDatos() {
		return baseDatos;
	}
	public void setBaseDatos(String value) throws SQLException{
		this.baseDatos = value;
		mysqlConnection = DriverManager.getConnection("jdbc:mysql://"+servidor+"/"+baseDatos+"?user="+usuario+"&password="+password);
	}
	
	private Connection mysqlConnection;
	public Connection getMysqlConnection() throws SQLException {
		if (mysqlConnection == null){
			mysqlConnection = DriverManager.getConnection("jdbc:mysql://"+servidor+"/"+baseDatos+"?user="+usuario+"&password="+password);
		}
		return mysqlConnection;
	}
	public void setBaseDatos(Connection value) throws SQLException{
		this.mysqlConnection = value;
	}
	
}
