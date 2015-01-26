package hibernate;

import java.math.BigDecimal;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;

import org.hibernate.annotations.GenericGenerator;

public class Articulo {
	
	private Long id;
	private String nombre;
	private Long categoria;
	private BigDecimal precio;
	
	@Id
	@GeneratedValue(generator="increment")
	@GenericGenerator(name="increment", strategy = "increment")
    public Long getId() {
		return id;
    }

    private void setId(Long id) {
		this.id = id;
    }
    
    public String getNombre() {
		return nombre;
    }

    public void setNombre(String nombre) {
		this.nombre = nombre;
    }
    
    public Long getCategoria() {
		return categoria;
    }

    public void setCategoria(Long categoria) {
		this.categoria = categoria;
    }
    
    public BigDecimal getPrecio() {
		return precio;
    }

    public void setPrecio(BigDecimal precio) {
		this.precio = precio;
    }
}