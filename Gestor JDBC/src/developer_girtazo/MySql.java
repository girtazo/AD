package developer_girtazo;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Scanner;





public class MySql {

	private static Scanner scanner = new Scanner(System.in);
	public static void main(String[] args) throws ClassNotFoundException,SQLException{
		// TODO Auto-generated method stub
		System.out.print("Dime tu nombre");
		String nombre = scanner.nextLine();
		System.out.println("Hola "+nombre);
		//Class.forName("com.mysql.jdbc.Driver");
		Connection conexion = DriverManager.getConnection("jdbc:mysql://localhost/dbprueba?user=root&password=sistemas");
		//Statement statement = (Statement) conexion.createStatement();
		//ResultSet resultSet = statement.executeQuery("select * from categoria");
		PreparedStatement preparedStatement = conexion.prepareStatement("select * from categoria where nombre like ?");
		//preparedStatement.setLong(1, 7);
		preparedStatement.setObject(1, "%a%");
		ResultSet resultado = preparedStatement.executeQuery();
		
		while(resultado.next()){
			System.out.printf("id=%4s nombre=%s \n",resultado.getObject("id"),resultado.getObject("nombre"));
		}
		
		resultado.close();
		preparedStatement.close();
		conexion.close();
	}

}
