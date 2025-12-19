# **codeReview 1 14/11/25**



usare nomi ben distinti e determinati, clean code quindi migliorare spaziature inutili ed eccessive



nome classe astratta modello generico, gerarchia per modellare, 



protected set = modificatore di acceso, che può modificare quella proprietà all'interno della classe stessa, ma anche dalle classe figlie.

&nbsp;dentro classe astratta :

public DateTime CreatedAtUtc {get; protected set;}//momento in qui si è creata.



public DateTime LastModifiedAtUtc { get; protected; }//momento in qui viene modificato lo stato dell'oggetto.



si può fare il costruttore dentro a classe astratta, ma non verrà mai istanziata .magari ti da una base per le classi figlie.



nome parametro deve essere lo stesso.



public void Dimmer(int amount)//aumento brightness di quantità scelta da utente.



enum class: acceso, spento powersavemode ecc.



es.

&nbsp;	public enum DeviceStatus

&nbsp;	{

&nbsp;		

&nbsp;		Unknown,

&nbsp;		

&nbsp;		Off,

&nbsp;		

&nbsp;		On,

&nbsp;	

&nbsp;		Standby,

&nbsp;	

&nbsp;		Error,



&nbsp;	}



classe astratta:



Status = DeviceStatus.Off;







# **Code Review #2 - 19/12/25**



**UML:**

* **Tutti i metodi e properties vanno esplicitate/i**
* **MatrixLed**



**SW:**

* **TurnOff() implementare come TurnOn() in AbstractDevice**
* **public virtual void increaseBrightness() { } -> o classe astratta con metodi astratti e virtual, oppure senza virtual**
* **TEST: SmartHouse-test rinominare in BlaisePascal.SmartHouse.Domain**
* **Folder "Abstractions" in Device folder**
* **namespace SmartHouse.domain.Devices in tutti i namespace**
* **public void Rename\_ShouldChangeName() implementare anche gli ulteriori blocchi non analizzati (esempio quando tira l'exception). Questa cosa va rifatta e ricontrollata per ogni metodo e test**
* **MatrixLed**



**DOC:**

* **inserire link drawio**
* **descrittiva a livello di funzionalità astraendo dalla specificità del design e codice**









































