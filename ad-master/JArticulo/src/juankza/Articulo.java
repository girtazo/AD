//GitHub>@juankza
package juankza;

import java.util.Scanner;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class Articulo
{
	private static Scanner scan = new Scanner(System.in);
	private static Connection connection;
	private static boolean exit = false;
	
	private static Connection connection(String user, String pwd)
	{
		Connection connection = null;
		try{
			connection = DriverManager.getConnection(
					"jdbc:mysql://localhost/dbprueba?user=" +user+ "&password=" +pwd);
			
		}
		catch(SQLException sql){
			System.out.println("\nUnnable to connect to database.\nError 404.");
			System.exit(0);
			
		}
		
		return connection;
		
	}
	
	private static void newArt()
	{
		//INSERT INTO `dbprueba`.`articulo` (`id`, `nombre`, `categoria`, `precio`) VALUES (NULL, 'articulo 0', '1', '5,25');
		System.out.println("--- Nuevo articulo ---");
		
		System.out.print("ID: ");
		int id = Integer.parseInt(scan.nextLine());
		
		System.out.print("Nombre: ");
		String name = scan.nextLine();
		
		System.out.print("Categoria: ");
		int cat = Integer.parseInt(scan.nextLine());
		
		System.out.print("Precio: ");
		double pvp = Double.parseDouble(scan.nextLine());
		
		try{
			PreparedStatement pStatement = connection.prepareStatement(
					"INSERT INTO `dbprueba`.`articulo` (`id`, `nombre`, `categoria`, `precio`) " +
					"VALUES (?, ?, ?, ?);");
			pStatement.setObject(1, id); pStatement.setObject(2, name);
			pStatement.setObject(3, cat); pStatement.setObject(4, pvp);
			
			pStatement.executeUpdate();
			
			pStatement.close();
			
		}
		catch(Exception e){ }
		
	}
	
	private static void editArt()
	{
		
		
	}
	
	private static void delArt()
	{
		
		
	}
	
	private static void seeArt()
	{
		System.out.println("\n0.Salir\n1.Visualizar todo\n2.Buscar por ID");
		int option = Integer.parseInt(scan.nextLine());
		
		try{
			if(option == 1)
			{
				PreparedStatement pStatement = connection.prepareStatement("SELECT * FROM articulo");
				
				ResultSet resultSet = pStatement.executeQuery();
				while(resultSet.next())
				{
					System.out.printf("| id = %s || nombre = %s || cat = %s || precio = %s |\n",
						resultSet.getObject("id"), resultSet.getObject("nombre"),
						resultSet.getObject("categoria"), resultSet.getObject("precio"));
					
				}
				
				resultSet.close();
				pStatement.close();
				
			}
			
			if(option == 2)
			{
				System.out.print("ID de busqueda: ");
				String id = scan.nextLine();
				PreparedStatement pStatement = connection.prepareStatement("SELECT * FROM articulo WHERE id like ?");
				pStatement.setObject(1, id);
				
				ResultSet resultSet = pStatement.executeQuery();
				while(resultSet.next())
				{
					System.out.printf("| id = %s || nombre = %s || cat = %s || precio = %s |\n",
						resultSet.getObject("id"), resultSet.getObject("nombre"),
						resultSet.getObject("categoria"), resultSet.getObject("precio"));
					
				}
				
				resultSet.close();
				pStatement.close();
				
			}
			
		}
		catch(Exception e){ }
		
	}
	
	public static void main(String[] args)
	{
		System.out.print("Username: ");
		String user = scan.nextLine();
		
		System.out.print("Password: ");
		String pwd = scan.nextLine();
		
		connection = connection(user, pwd);
		
		while(!exit)
		{
			System.out.println("\n0.Salir | 1.Nuevo | 2.Editar | 3.Eliminar | 4.Visualizar");
			int option = Integer.parseInt(scan.nextLine());
			
			switch(option)
			{
				case 0:{ System.out.print("\nSaliendo..."); exit = true; break;}
				case 1:{ newArt(); break;}
				case 2:{ editArt(); break;}
				case 3:{ delArt(); break;}
				case 4:{ seeArt(); break;}
				default:{ System.out.print("\nOpcion no encontrada."); break;}
			
			}
			
		}
		
		try{ connection.close();}
		catch(SQLException sql){ System.out.print(sql.getMessage());}
		
	}

}
