import javax.persistence.Entity;
import javax.persistence.Id;


@Entity
public class Categoria {
	
	//@Table( name = "Categoria" )
	public class Event {
	   private Long id;
	   private String nombre;
	}
	
	@Id
	public Long getId(){
		return id;
	}
	
	private void setId(Long Id){
		this.id = id;
	}
}
