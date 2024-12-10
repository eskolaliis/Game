using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Animator animator;

    public Transform targetPoint; // Tavoitepaikka pelaajan edessä
    public float speed = 5f; // Lentonopeus
    public float startDelay = 10f; // Viive ennen lentämistä

    private bool isFlyingToTarget = false; // Tila: lentääkö lintu kohteeseen
    public GameObject puzzleUI; // Viittaus Puzzle UI -elementtiin


    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("StartFlyingToTarget", startDelay); // Aloita lentäminen viiveen jälkeen
    }

    void Update()
{
    Debug.Log($"isFlying: {animator.GetBool("isFlying")}, isLanding: {animator.GetBool("isLanding")}, isIdle: {animator.GetBool("isIdle")}");
    if (isFlyingToTarget)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            LandAtTarget();
        }
    }
}


    public void StartFlyingToTarget()
    {
        animator.SetBool("isFlying", true); // Käynnistä lentämisanimaatio
        isFlyingToTarget = true; // Käynnistä liikkuminen
    }

   private void LandAtTarget()
{
    isFlyingToTarget = false; // Lopeta liike
    Debug.Log("Landing triggered"); // Tarkistusviesti
    animator.SetTrigger("startLanding"); // Aktivoi laskeutumisen triggeri
    animator.SetBool("landing", true); // Aktivoi landing-parametri
    Invoke(nameof(SetIdleState), 2f); // Siirry idle-tilaan viiveellä
}

private void SetIdleState()
{
    Debug.Log("Switching to idle state."); // Tarkistus, että idle-tila saavutetaan
    animator.SetBool("landing", false); // Poista landing-tunnus
    animator.SetBool("perched", true); // Aktivoi perched-tunnus
}

private void OnMouseDown()
    {
        if (!isFlyingToTarget) // Kun lintu on paikallaan
        {
            Debug.Log("Klikattiin lintua!");
            if (puzzleUI != null)
            {
                puzzleUI.SetActive(true); // Aktivoi Puzzle UI
            }
        }
    }



}
