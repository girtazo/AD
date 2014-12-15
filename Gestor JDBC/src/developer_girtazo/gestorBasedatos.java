package developer_girtazo;

import java.io.ObjectInputStream.GetField;
import java.lang.reflect.GenericArrayType;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.sql.Statement;
import java.sql.ResultSet;
import java.sql.Types;
import java.util.ArrayList;
import java.util.Hashtable;
import java.util.List;
import java.util.Scanner;

import org.omg.CORBA.Any;
import org.omg.CORBA.DATA_CONVERSION;
import org.omg.CORBA.TCKind;
import org.omg.CORBA.TypeCode;
import org.omg.CORBA.TypeCodePackage.BadKind;
import org.omg.CORBA.TypeCodePackage.Bounds;

public class gestorBasedatos {
	private static Scanner scanner = new Scanner(System.in);
	private static Tabla tabla;
	public static void main(String[] args) throws SQLException {
		
		tabla = new Tabla("categoria");
		int opcion =1;
		
		while(opcion != 0){
			
			System.out.println("----------------");
			System.out.println("0 - Salir");
			System.out.println("1 - Listar");
			System.out.println("2 - Insertar");
			System.out.println("3 - Modificar");
			System.out.println("4 - Borrar");
			System.out.println("----------------");
			System.out.print("Elige opcion:");
			opcion = Integer.parseInt(scanner.nextLine());
			
			switch (opcion) {
			case 1:
				
				listar();
				break;
			
			case 2:
				
				insertar();
				listar();
				break;
				
			case 3:
				modificar();
				break;
			
			case 4:
				borrar();
				break;
				
			}
			
		}
		
	}
	
	public static void listar() throws SQLException{
		
		ArrayList<Campo> campos = tabla.getCampos();
		ArrayList<Hashtable> valores = tabla.listar();
		
		// Visualizacion de Campos Tabla
		for (Campo campo : campos) {
			System.out.print(campo.nombre+"	");
		}
		
		System.out.println();
		
		// Visualizacion de Valores Tabla
		for (Object tupla :  valores) {
			Hashtable<String, Object> valor = (Hashtable<String, Object>) tupla;
				for (Campo campo : campos) {
					System.out.print(valor.get(campo.nombre)+"	");
				}
				System.out.println();
		}
		
	}
	
	public static void insertar() throws SQLException{
		
		ArrayList<Campo> campos = tabla.getCampos();
		Hashtable<String, Object> tupla = new Hashtable<String, Object>();

		// Visualizacion de Campos Tabla
		for (Campo campo : campos) {
			if( !campo.nombre.contentEquals("id") ){
				System.out.print("Introduce lo que desea insertar en "+campo.nombre+":");
				tupla.put( campo.nombre, (Object) scanner.nextLine());
			}
			
		}
		
		tabla.insertar(tupla);
	}

	public static void modificar() throws SQLException{
		
		ArrayList<Campo> campos = tabla.getCampos();
		Hashtable<String, Object> tupla = new Hashtable<String, Object>();
		Hashtable<String, Object> select = new Hashtable<String, Object>();
		
		
		// Visualizacion de Tabla
		listar();
		
		System.out.print("Elige el registro a modificar:");
		int id= Integer.parseInt(scanner.nextLine());
		select.put("id",id);
		
		for (Campo campo : campos) {
			
			if( !campo.nombre.contentEquals("id") ){
				System.out.print("Introduce lo que desea insertar en "+campo.nombre+":");
				tupla.put( campo.nombre, (Object) scanner.nextLine());
			}
			
		}
		
		
		tabla.modificar( tupla, select );
		
	}

	public static void borrar() throws SQLException{
		
		ArrayList<Campo> campos = tabla.getCampos();
		Hashtable<String, Object> tupla = new Hashtable<String, Object>();
		
		
		// Visualizacion de Tabla
		listar();
		
		System.out.print("Elige el registro a modificar:");
		int id= Integer.parseInt(scanner.nextLine());
		
		tupla.put("id", id);
		
		tabla.borrar(tupla);
		
		listar();
		
	}
}
