
public static class G {

	var maxTucumas : int = 10;
	var Tucumas : int = 5;
	
	
	var numPlayers : int = 4;
	var firstPlay : boolean = true;
	public var currentPlayer : int = 0;
	var gamePaused : boolean = false;
	var isFadding = false;
	var showTutorial : boolean = false;
	var showPauseBtn : boolean = false;
	
	var cameraFade : float = 0.5;
	
	var audioEffects : boolean = true;
	var effectsVol : float = 1;
	var audioAmbience : boolean = true;
	var ambienceVol : float = 1;
	
	//tela de apresentacao (tela travada inicial)
	var presentScreen : boolean = true;
	
	function maiorTagId() : int {
		var max : float = Mathf.Max(tagPos);
		if (max == tagPos[0]) {
			return 0;
		} else if (max == tagPos[1]) {
			return 1;
		} else if (max == tagPos[2]) {
			return 2;
		} else {
			return 3;
		}
		
	}
	
	function setTag(p : float) {
		tagPos[currentPlayer] = p;
	}
	
	var playerUltimoRecurso : int[] = [
	0,
	0,
	0,
	0
	];
	
	var playerUltimoInseto : int[] = [
	0,
	0,
	0,
	0
	];
	
	var boardPosition : int[] = [
	2,
	18,
	13,
	27
	];
	
	var tagPos : float[] = [
	0.0,
	0.0,
	0.0,
	0.0
	];
	
	var playersName : String[] = [
	"Jogador 1",
	"Jogador 2",
	"Jogador 3",
	"Jogador 4"
	];
	
	var playerSkinType : int[] = [
	0,
	1,
	2,
	1
	];
	
	var playerHairType : int[] = [
	0,
	1, 
	2,
	3
	];
	
	var playerInsectType : int[] = [
	0,
	1,
	2,
	3
	];
	
	var typePlayerName : String[] = [
	"Corydalidae",
	"Calopterygidae",
	"Calamoceratidae",
	"Leptophlebiidae",
	"Elmidae",
	"Simuliidae"
	];
	
	var typeInsetoDesc : String[] = [
	"Larvas são predadoras e se alimentam de insetos e outros invertebrados . Vivem em áreas de correnteza ou remanso e diferentes substratos. Algumas espécies são pouco sensíveis a perturbação antropogênica.",
	"Larvas são predadoras de pequenos insetos e outros invertebrados. Vivem em áreas de correnteza e diversos substratos. São sensíveis a perturbação antropogênica.",
	"Larvas são fragmentadoras, se alimentam de folhas. Vivem em áreas de remanso e substrato folhas. São sensíveis a perturbação antropogênica.",
	"Larva são coletoras, se alimentam de detritos, algas e fungos. Vivem em áreas de remanso sob substrato  folhas e pedras. São sensíveis a perturbação antropogênica.",
	"Larvas são raspadoras, se alimentam de algas e fungos. Vivem em áreas de correnteza e substratos folhas, troncos e pedras. São sensíveis a perturbação antropogênica. ",
	"Larvas são filtradoras, se alimentam de “seston” (algas, fungos e detrito em suspensão). Vivem em áreas de correnteza e diferentes substratos. Algumas espécies são pouco sensíveis a perturbação antropogênica."
	];
	
	var typePlayerLevel : int[] = [
	2,
	4,
	4,
	5,
	5,
	5
	];
	
	var playerPularVez : boolean[] = [
	false,
	false,
	false,
	false
	];
	
	var playerSexo : boolean[] = [
	true,
	false,
	false,
	false
	];
	
	var isNPC : boolean[] = [
	false,
	false,
	false,
	false
	];
	
	var typePredatorName : String[] = [
	"Peixes",
	"Peixes",
	"Peixes",
	"Corydalidae",
	"Camarão",
	"Belostomatidae",
	"Gomphidae",
	"Aeshnidae",
	"Libellulidae",
	"Calopterygidae",
	"Perlidae",
	"Hydrobiosidae",
	"Tabanidae",
	"Chironomidae",
	"Ceratopogonidae"
	];
	
	var typePredatorDesc : String[] = [
	"São predadores de todos os invertebrados.",
	"São predadores de todos os invertebrados.",
	"São predadores de todos os invertebrados.",
	"Larvas são predadoras de todos os invertebrados aquáticos.",
	"São predadores de pequenos  peixes  e invertebrados, incluindo ninfas de Odonata e Plecoptera.",
	"Adultos e ninfas são predadores de pequenos  peixes  e Invertebrados, incluindo ninfas de Odonata e Plecoptera.",
	"Ninfas são predadoras de  todos os insetos aquáticos e outros invertebrados aquáticos.",
	"Ninfas são predadoras de insetos aquáticos e outros invertebrados.",
	"Ninfas são predadoras de insetos aquáticos e outros invertebrados.",
	"Ninfas são predadoras de larvas de insetos aquáticos e outros invertebrados.",
	"Ninfas são predadoras de larvas de insetos aquáticos e outros invertebrados.",
	"Larvas são predadoras de larvas de insetos aquáticos e outros invertebrados.",
	"Larvas são predadoras de larvas pequenas de insetos aquáticos e outros invertebrados.",
	"Larvas são predadoras de larvas pequenas de insetos aquáticos e outros invertebrados.",
	"Larvas são predadoras de larvas pequenas de insetos aquáticos e outros invertebrados."
	];
	
	var typePredator : int[] = [
	1,
	1,
	1,
	2,
	2,
	2,
	3,
	3,
	3,
	4,
	4,
	4,
	5,
	5,
	5
	];
	
	var typeRecursoName : String[] = [
	"Alga", /* 0 */
	"Fungo", /* 1 */
	"Folhas", /* 2 */
	"Madeira", /* 3 */
	"Detritos", /* 4 */
	"Larvas de Chironomidae", /* 5 */
	"Larvas de Simuliidae", /* 6 */
	"Ninfas de Ephemeroptera" /* 7 */
	];
	
	var typeRecursoDesc : String[] = [
	"Diversas algas microscópicas vivem no ambiente aquático, tanto livres (planctônicas) quanto sobre diferentes substratos (perifito).",
	"Diversos fungos microscópicos vivem no ambiente aquático, incluindo decompositores de folhas e madeira.",
	"Folhas, frutos e flores submersos, provenientes da floresta às margens de igarapés e rios (vegetação ripária) servem de alimento e abrigo para uma grande diversidade de animais.",
	"Galhos e troncos submersos, provenientes da floresta às margens de igarapés e rios (vegetação ripária) servem de alimento e abrigo para uma grande diversidade de animais.",
	"Detrito proveniente do processamento da matéria orgânica grossa fornecida pela floresta às margens de igarapés e rios (vegetação ripária) servem de alimento e abrigo para uma grande diversidade de animais.",
	"Larvas de Chironomidae são abundantes em ambientes lóticos e lênticos. Representam importante fonte alimentar para diversos invertebrados e vertebrados aquáticos.",
	"Larvas de Simuliidae são abundantes em ambientes lóticos. Representam importante fonte alimentar para diversos invertebrados e vertebrados aquáticos.",
	"Larvas de Ephemeroptera vivem em ambientes lóticos e lênticos. Representam importante fonte alimentar para diversos invertebrados e vertebrados aquáticos."
	];

}