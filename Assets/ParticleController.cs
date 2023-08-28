using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ParticleController : MonoBehaviour
{
    public TextAsset csvFile; // CSV文件作为TextAsset
    public float xSpeed; // 粒子在X轴上的速度
    public float emitInterval = 8.0f; // 粒子发射间隔（秒）

    private ParticleSystem myParticleSystem; // 重命名以避免冲突
    private List<float> yPositions = new List<float>();
    private float timeSinceLastEmit = 0;

    // Start is called before the first frame update
    private void Start()
    {
        myParticleSystem = GetComponent<ParticleSystem>(); // 重命名以避免冲突
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
        myParticleSystem.Emit(emitParams, 1); // 重命名以避免冲突
    }

    private IEnumerator UpdateParticlePositions()
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[myParticleSystem.main.maxParticles]; // 重命名以避免冲突

        while (true)
        {
            int particleCount = myParticleSystem.GetParticles(particles); // 重命名以避免冲突

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

            myParticleSystem.SetParticles(particles, particleCount); // 重命名以避免冲突

            yield return new WaitForSeconds(1 / 300.0f);
        }
    }
}
