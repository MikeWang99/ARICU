using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ParticleController : MonoBehaviour
{
    public TextAsset csvFile; // CSV�ļ���ΪTextAsset
    public float xSpeed; // ������X���ϵ��ٶ�
    public float emitInterval = 8.0f; // ���ӷ��������룩

    private ParticleSystem myParticleSystem; // �������Ա����ͻ
    private List<float> yPositions = new List<float>();
    private float timeSinceLastEmit = 0;

    // Start is called before the first frame update
    private void Start()
    {
        myParticleSystem = GetComponent<ParticleSystem>(); // �������Ա����ͻ
        LoadYPositionsFromCSV();
        StartCoroutine(UpdateParticlePositions());
    }

    // Update is called once per frame
    private void Update()
    {
        timeSinceLastEmit += Time.deltaTime;

        if (timeSinceLastEmit >= emitInterval)
        {
            EmitParticle();
            timeSinceLastEmit = 0;
        }
    }

    private void LoadYPositionsFromCSV()
    {

        string[] lines = csvFile.text.Split(new[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            string[] entries = line.Split(',');
            yPositions.Add(float.Parse(entries[0]));
        }
    }

    private void EmitParticle()
    {
        ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
        emitParams.velocity = new Vector3(xSpeed, 0, 0);
        myParticleSystem.Emit(emitParams, 1); // �������Ա����ͻ
    }

    private IEnumerator UpdateParticlePositions()
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[myParticleSystem.main.maxParticles]; // �������Ա����ͻ

        while (true)
        {
            int particleCount = myParticleSystem.GetParticles(particles); // �������Ա����ͻ

            for (int i = 0; i < particleCount; i++)
            {
                float age = particles[i].startLifetime - particles[i].remainingLifetime;
                int index = Mathf.FloorToInt(age * 300);

                if (index < yPositions.Count)
                {
                    Vector3 pos = particles[i].position;
                    pos.y = yPositions[index];
                    particles[i].position = pos;
                }
            }

            myParticleSystem.SetParticles(particles, particleCount); // �������Ա����ͻ

            yield return new WaitForSeconds(1 / 300.0f);
        }
    }
}
