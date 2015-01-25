package serpis.ad;

import java.util.Scanner;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class MySql
{
	public static void main(String[] args) throws ClassNotFoundException, SQLException
	{
		//Class.forName("com.mysql.jdbc.Driver"); NECESSARY on TYPE 3 or less
		Scanner scan = new Scanner(System.in);
		String user, pwd = "";
		
		System.out.print("Hello MySql.\nUser for new connection: ");
		user = scan.nextLine();
		
		System.out.print("Password for user " +user+ ": ");
		pwd = scan.nextLine();
		
		Connection connection = null;
		try{
			connection = DriverManager.getConnection(
					"jdbc:mysql://localhost/dbprueba?user=" +user+ "&password=" +pwd);
			
		}
		catch(Exception e){
			System.out.println("\nUnnable to connect to database.\nError 404.");
			System.exit(0);
			
		}
		
		//Statement statement = connection.createStatement();
		//ResultSet resultSet = statement.executeQuery("SELECT * FROM categoria");
		
		PreparedStatement pStatement = connection.prepareStatement("SELECT * FROM categoria WHERE nombre like ?");
		pStatement.setObject(1, "%a%");
		ResultSet resultSet = pStatement.executeQuery();
		
		while(resultSet.next())
		{
			System.out.printf("id = %s \t nombre = %s \n", resultSet.getObject("id"), resultSet.getObject("nombre"));
			
		}
		
		resultSet.close();
		//statement.close();
		pStatement.close();
		connection.close();
		
	}

}
