package developer_girtazo;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.sql.Statement;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.Hashtable;
import java.util.List;
import java.util.Scanner;

public class gestorBasedatos {
	private static Scanner scanner = new Scanner(System.in);
	public static void main(String[] args) throws SQLException {
		Tabla tabla = new Tabla("categoria");
		System.out.println("----------------");
		System.out.println("1 - Listar");
		System.out.println("2 - Insertar");
		System.out.println("3 - Modificar");
		System.out.println("4 - Borrar");
		System.out.println("----------------");
		System.out.print("Elige opcion:");
		int opcion = Integer.parseInt(scanner.nextLine());
		switch (opcion) {
		case 1:
			
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
			break;

		default:
			break;
		}
	}
}
