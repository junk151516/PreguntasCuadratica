using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Indicadores : MonoBehaviour {


	public bool estado;
	public Animator animator;
	public Text valores;
	public Text valores2;
	public GameObject vertice;
	public GameObject intersepto1;
	public Text intersepto1Texto;
	public GameObject intersepto2;
	public Text intersepto2Texto;
	public GameObject sliders;
	public Image botonFuncion;
	public Image botonMenu;
	public Image botonVertice;
	public Image botonIntercepto;
	public Image botonValores;

	public GameObject fondoVertice;
	public GameObject fondointerceptos;
	public GameObject fondoVertice2;


	public Sprite spriteMenuOn;
	public Sprite spriteMenuOff;
	public Sprite verticeOn;
	public Sprite verticeOff;
	public Sprite interceptoOn;
	public Sprite interceptoOff;
	public Sprite slidersOn;
	public Sprite slidersOff;
	public Sprite funcionOn;
	public Sprite funcionOff;


	float a = 1;
	float b = 0;
	float c = 0;
	string cuadratica ;
	string interceptos;
	string vertices;
	string funcion;

	public bool banderaVertice = false;
	public bool banderaFuncion = false;
	public bool banderainterceptos = false;
	public bool banderaSliders = true;

	public Text[] interceptoText;
	public Text[] verticeText;

	public Text tm ;


	float h = 0;
	float k = 0;
	// Use this for initialization
	void Start () {
		crearGrafica();
		//animator.SetBool("cerrar", true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void cerrar(){
		if(estado){
			animator.SetBool("cerrar", false);
			estado = false;
			botonMenu.sprite = spriteMenuOff;
		}else{
			animator.SetBool("cerrar", true);
			estado = true;
			botonMenu.sprite = spriteMenuOn;
		}
	}
	public void activaSliders(){
		if(banderaSliders){
			sliders.SetActive(false);
			banderaSliders = false;
			botonValores.sprite = slidersOn;
		}else{
			sliders.SetActive(true);
			banderaSliders = true;
			botonValores.sprite = slidersOff;
		}
	}


	public void activaFuncion( ){
		if(!banderaFuncion){

			if(banderainterceptos){
				activaIntersepto();
			}
			if(banderaVertice){
				activaVertice();
			}

			fondoVertice.gameObject.SetActive(true);
			banderaFuncion = true;
			banderainterceptos = false;
			banderaVertice = false;
			valores.text = "";
			string funcion2="";
			valores2.text = "";
			funcion = "f(x) =  <color=#FFE600>"+a.ToString ("n2")+" </color>e";
			funcion2= funcion2 + "<color=#00A7FF>"+b.ToString ("n2")+"</color>x"; 
		

			valores.text = valores.text + funcion;
			valores2.text = valores2.text +funcion2;
			botonFuncion.sprite = funcionOff;

		}else{
			banderaFuncion = false;
			banderainterceptos = false;
			banderaVertice = false;
			botonFuncion.sprite = funcionOn;
			fondoVertice.gameObject.SetActive(false);
		}
	}
	public void activaIntersepto( ){
		if(!banderainterceptos){
			if(banderaFuncion){
				activaFuncion();
			}
			if(banderaVertice){
				activaVertice();
			}

			fondointerceptos.gameObject.SetActive(true);
			banderainterceptos = true;
			intersepto1.GetComponent<Animator>().enabled=true;
			intersepto2.GetComponent<Animator>().enabled=true;
			intersepto1Texto.gameObject.SetActive(true);
			intersepto2Texto.gameObject.SetActive(true);
			botonIntercepto.sprite = interceptoOff;
		}else{
			fondointerceptos.gameObject.SetActive(false);
			banderainterceptos = false;
			intersepto1.GetComponent<Animator>().enabled=false;
			intersepto2.GetComponent<Animator>().enabled=false;
			intersepto1.GetComponent<MeshRenderer>().enabled=true;
			intersepto2.GetComponent<MeshRenderer>().enabled=true;
			intersepto1Texto.gameObject.SetActive(false);
			intersepto2Texto.gameObject.SetActive(false);
			botonIntercepto.sprite = interceptoOn;
		
		}
	}
	public void activaVertice( ){
		if(!banderaVertice){
			if(banderaFuncion){
				activaFuncion();
			}
			if(banderainterceptos){
				activaIntersepto();
			}

			fondoVertice2.gameObject.SetActive(true);
			banderaVertice = true;
			vertice.GetComponent<Animator>().enabled=true;
			//tm = vertice.GetComponentInChildren<TextMesh>();
			tm.transform.gameObject.SetActive(true);
			tm.text= "("+h.ToString ("n2")+","+k.ToString ("n2")+")";
			botonVertice.sprite = verticeOff;
		}else{
			vertice.GetComponent<Animator>().enabled=false;
			vertice.GetComponent<MeshRenderer>().enabled=true;
			fondoVertice2.gameObject.SetActive(false);
			tm.transform.gameObject.SetActive(false);
			banderaVertice = false;
			botonVertice.sprite = verticeOn;

		}
	}
	public void cambiarA(float nA)
	{
		a=nA;
		crearGrafica();
	}
	
	public void cambiarB(float nB)
	{
		b=nB;
		crearGrafica();
	}
	
	public void cambiarC(float nC)
	{
		c=nC;
		crearGrafica();
	}
	public void crearGrafica(){
		//if (banderaFuncion){

		valores.text = "";
		string funcion2="";
		valores2.text = "";
		funcion = "f(x) =  <color=#FFE600>"+a.ToString ("n2")+" </color>e";
		funcion2= funcion2 + "<color=#00A7FF>"+b.ToString ("n2")+"</color>x"; 
		
		
		valores.text = valores.text + funcion;
		valores2.text = valores2.text +funcion2;
		botonFuncion.sprite = funcionOff;

	//	}
		//if(banderainterceptos){
			//valores.text = "interceptos\n";
			interceptos = "x1=(-b+(b*b-4ac))/2a\nx2=(-b-(b*b-4ac))/2a";
			interceptoText[0].text= "-(<color=#00A7FF>"+b.ToString ("n2")+"</color>)+"; 
			interceptoText[1].text= "(<color=#00A7FF>"+b.ToString ("n2")+"</color>)²-4"+
									"(<color=#FFE600>"+a.ToString ("n2")+"</color>)"+
									"(<color=#3EFF00>"+c.ToString ("n2")+"</color>)";

			interceptoText[2].text="2(<color=#FFE600>"+a.ToString ("n2")+"</color>)";
			interceptoText[3].text= "-(<color=#00A7FF>"+b.ToString ("n2")+"</color>)-"; 
			interceptoText[4].text= "(<color=#00A7FF>"+b.ToString ("n2")+"</color>)²-4"+
									"(<color=#FFE600>"+a.ToString ("n2")+"</color>)"+
									"(<color=#3EFF00>"+c.ToString ("n2")+"</color>)";
		
			interceptoText[5].text="2(<color=#FFE600>"+a.ToString ("n2")+"</color>)";
			//valores.text = valores.text + interceptos;
			if(((b*b)-(4*a*c))<0){ // no tiene interceptos
			interceptoText[6].text="=IND";
			interceptoText[7].text="=IND";
						}else{
			interceptoText[6].text="="+((-b+(Mathf.Sqrt ((b*b)-(4*a*c))))/(2*a)).ToString ("n2");
			interceptoText[7].text="="+((-b-(Mathf.Sqrt ((b*b)-(4*a*c))))/(2*a)).ToString ("n2");
			intersepto1Texto.text = ((-b+(Mathf.Sqrt ((b*b)-(4*a*c))))/(2*a)).ToString ("n2");
			intersepto2Texto.text = ((-b-(Mathf.Sqrt ((b*b)-(4*a*c))))/(2*a)).ToString ("n2");
			}


			

	//	}		
	//	if(banderaVertice){
			h = -b/(2*a);
			k = a*(h)*(h)+b*(h)+c;
			//valores.text = "Vertice (h,k) ("+h.ToString ("n2")+","+k.ToString ("n2")+")\n";
			vertices = "h = -b/2a\nk = f(-b/2a)";
			//valores.text = valores.text + vertices;
			verticeText[0].text="-(<color=#00A7FF>"+b.ToString ("n2")+"</color>)";
			verticeText[1].text="2(<color=#FFE600>"+a.ToString ("n2")+"</color>)";
			verticeText[2].text=h.ToString ("n2");
			//verticeText[3].text="2(<color=#FFE600>"+a.ToString ("n2")+"</color>)";
			verticeText[4].text="= "+h.ToString ("n2");
			verticeText[5].text="= "+k.ToString ("n2");
			tm.text= "("+h.ToString ("n2")+","+k.ToString ("n2")+")";
	
	//	}		
	}
}
