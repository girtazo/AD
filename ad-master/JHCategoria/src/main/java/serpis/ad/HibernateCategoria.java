package serpis.ad;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

public class HibernateCategoria
{
	private static EntityManagerFactory entityManagerFactory;

	public static void main(String[] args)
	{
		entityManagerFactory = Persistence.createEntityManagerFactory("serpis.ad.jpa.mysql");
		
		showCategorias();
		
		System.out.println("Añado categorias "); persistNuevasCategorias();
		
		showCategorias();
		
		entityManagerFactory.close();

	}

	public static void persistNuevasCategorias()
	{
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		
		entityManager.getTransaction().begin();
		
		Categoria categoria = new Categoria();
		categoria.setNombre("Hibernate " +new SimpleDateFormat("yyyy-MM-dd HH:mm:ss").format(new Date()));
		entityManager.persist(categoria);
		
		entityManager.getTransaction().commit();
		
		entityManager.close();
		
	}
	
	public static void showCategorias()
	{
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		
		entityManager.getTransaction().begin();
		
		List<Categoria> categorias = entityManager.createQuery("FROM Categoria", Categoria.class).getResultList();
		for (Categoria categoria : categorias)
			System.out.printf("id=%d \t nombre=%s\n", categoria.getId(), categoria.getNombre());
		
		entityManager.getTransaction().commit();
		
		entityManager.close();
		
	}
	
}
