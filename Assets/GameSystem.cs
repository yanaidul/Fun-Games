using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameSystem : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameSystem instance;


    public static bool  NewGame = true;

    [Header("Data Permainan")]
    public bool GameAktif;
    public bool GameSelesai;
    public bool SistemAcak;
    public int Target,DataSaatIni;
    public int DataLevel, DataScore, DataWaktu, DataDarah;


    [Header("Komponen UI")]
    public Text Teks_level,Teks_Waktu, Teks_Score;
    public RectTransform Ui_Darah;

    




    [System.Serializable]


    public class DataGame{
        public string Nama;
        public Sprite Gambar;
        
    }

    [Header("Settingan Standar")]
    public DataGame[] DataPermainan;


    [Space]
    

    public Obj_Drag[] Drag_obj;
    public Obj_TempatDrop[] Drop_Tempat;


    private void Awake(){
        instance = this;
    }
    

    void Start(){

        
        ResetData();
        Target = Drop_Tempat.Length;
        if(SistemAcak){
            AcakSoal();
            GameAktif = true;
        }
            
    }


    void ResetData(){
        if(NewGame){
            NewGame = false;
            
            DataDarah = 3;
            DataScore = 0;
            DataLevel = 0;

        }
    }


    void Update(){
            if(Input.GetKeyDown(KeyCode.Space))
                AcakSoal();

            if(GameAktif){
                if(DataWaktu > 0){
                    s += Time.deltaTime;
                    if(s >= 1){
                        DataWaktu--;
                        s = 0;
                    }
                }
            }
            SetInfoUI();
        }

    [HideInInspector]public List<int> _AcakSoal = new List<int>();
     [HideInInspector]public List<int> _AcakPos = new List<int>();
    int rand;
    int rand2;
    public void AcakSoal(){
        _AcakPos.Clear();
        _AcakSoal.Clear();
        _AcakSoal = new List<int>(new int[Drag_obj.Length]);
        for(int i = 0; i < _AcakSoal.Count; i++){
            rand = Random.Range(1, DataPermainan.Length);
            while(_AcakSoal.Contains(rand))
                rand = Random.Range(1, DataPermainan.Length);
                
            _AcakSoal[i] = rand;
            Drag_obj[i].ID = rand - 1;
            Drag_obj[i].Tesk.text = DataPermainan[rand - 1].Nama;
        }

        _AcakPos = new List<int>(new int[Drop_Tempat.Length]);
        for(int i = 0; i < _AcakPos.Count; i++){
            rand2 = Random.Range(1, _AcakSoal.Count + 1);
             while(_AcakPos.Contains(rand2))
                rand2 = Random.Range(1, _AcakSoal.Count + 1);

                
            _AcakPos[i] = rand2;

            Drop_Tempat[i].Drop.ID = _AcakSoal[rand2 -1] - 1;
            Drop_Tempat[i].Gambar.sprite = DataPermainan[Drop_Tempat[i].Drop.ID].Gambar;
            
        }
    }



    float s;
    
    public void SetInfoUI(){

        Teks_level.text = (DataLevel + 1).ToString() ;

        int Menit = Mathf.FloorToInt(DataWaktu / 60);
        int Detik = Mathf.FloorToInt(DataWaktu % 60);
        Teks_Waktu.text = Menit.ToString("00") + ":" + Detik.ToString("00");

        Teks_Score.text = DataScore.ToString();
        Ui_Darah.sizeDelta = new Vector2(40f * DataDarah , -17f );
    }
}
