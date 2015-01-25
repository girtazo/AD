package hibernate;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import java.util.Scanner;

import hibernate.Categoria;
import hibernate.Articulo;

public class Gestor {
	
	private EntityManagerFactory entityManagerFactory;
	private EntityManager entityManager;
	private static Scanner scanner;
	
	public Gestor(){
		
		scanner = new Scanner(System.in);
		entityManagerFactory = Persistence.createEntityManagerFactory("gestion");
		
	}
	
	public void listarCategoria(){
		
		entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		List<Categoria> categorias = entityManager.createQuery("FROM Categoria", Categoria.class).getResultList();
		for (Categoria categoria : categorias)
			System.out.printf("id: %d \t nombre=%s\n", categoria.getId(), categoria.getNombre());
		
		entityManager.getTransaction().commit();
		
		entityManager.close();
	}
	
	public void listarArticulo(){
		
		entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		List<Articulo> articulos = entityManager.createQuery("FROM Articulo", Articulo.class).getResultList();
		for (Articulo articulo : articulos)
			System.out.printf("id: %d \t nombre=%s\n", articulo.getId(), articulo.getNombre());
		
		entityManager.getTransaction().commit();
		
		entityManager.close();
	}
	
	public void insertarCategoria(){
		
		entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Categoria categoria = new Categoria();
		System.out.print("Nombre:");
		
		categoria.setNombre(scanner.nextLine());
		entityManager.persist(categoria);
		
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	
	public void insertarArticulo(){
		
		entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Articulo articulo = new Articulo();
		System.out.print("Nombre:");
		
		articulo.setNombre(scanner.nextLine());
		entityManager.persist(articulo);
		
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		Gestor gestor = new Gestor();
		
		int opcion = 1;
		
		while(opcion != 0){
			
			System.out.println("----------------");
			System.out.println("0 - Salir");
			System.out.println("1 - Listar Categoria");
			System.out.println("2 - Insertar Categoria");
			System.out.println("3 - Modificar Categoria");
			System.out.println("4 - Borrar Categoria");
			System.out.println("5 - Listar Articulo");
			System.out.println("6 - Insertar Articulo");
			System.out.println("7 - Modificar Articulo");
			System.out.println("8 - Borrar Articulo");
			System.out.println("----------------");
			System.out.print("Elige opcion:");
			
			opcion = Integer.parseInt(scanner.nextLine());
			
			switch (opcion) {
			case 1:
				
				gestor.listarCategoria();
				break;
			
			case 2:
				
				gestor.insertarCategoria();
				gestor.listarCategoria();
				break;
				
			case 3:
				
				break;
			
			case 4:
				
				break;
			
			case 5:
				gestor.listarArticulo();
				break;
				
			}
			
		}
	}
}
