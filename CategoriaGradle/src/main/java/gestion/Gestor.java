package gestion;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;



public class Gestor {
	
	private EntityManagerFactory database;
	private EntityManager entidad;
	
	public Gestor( ){
		this.database = Persistence.createEntityManagerFactory("gestion");
		this.entidad = database.createEntityManager();
	}

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Gestor gestor = new Gestor();
		gestor.listarTabla("Categoria");
		gestor.database.close();
	}
	public void listarTabla(String tabla){
		
		this.entidad.getTransaction().begin();
		List<Categoria> categorias = this.entidad.createQuery("FROM "+tabla,Categoria.class).getResultList();
		for(Categoria categoria : categorias){
			System.out.printf("id: %d \t nombre: %s\n",categoria.getId(),categoria.getNombre());
		}
		this.entidad.getTransaction().commit();
		this.entidad.close();
		
	}

}
