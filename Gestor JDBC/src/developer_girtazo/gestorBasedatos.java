package developer_girtazo;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.sql.Statement;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class gestorBasedatos {
	private static Scanner scanner = new Scanner(System.in);
	public static void main(String[] args) throws SQLException {
		Tabla tabla = new Tabla("categoria");
		// TODO Auto-generated method stub
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
			ArrayList<Object> valores = tabla.listar();
			int c=0;
			for (Object tupla :  valores) {
				List<String> valor = (List<String>) tupla;
				if(c == campos.size()){
					System.out.print(valor.get(c)+"	");
					c++;
				} else {
					System.out.println(valor.get(c));
					c=0;
				}
				
			}
			break;

		default:
			break;
		}
	}
}
