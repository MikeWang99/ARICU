using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleMotionController : MonoBehaviour
{
    public TextAsset CsvFile; // �Ϸ�CSV�ļ����˴�

    private ParticleSystem ps;
    private ParticleSystem.Particle[] particles;

    private List<float> ySpeeds = new List<float>();
    private float[] lastChangeTime;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[ps.main.maxParticles];
        lastChangeTime = new float[ps.main.maxParticles];

        // ��ȡCSV�ļ��ĵ�һ������
        string[] lines = CsvFile.text.Split(new[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            string[] entries = line.Split(',');
            ySpeeds.Add(float.Parse(entries[0]));
        }
    }

    private void EmitParticle()
    {
        ps.Emit(1);
        int alive = ps.GetParticles(particles);

        if (alive > 0)
        {
            int lastParticleIndex = alive - 1;
            Vector3 velocity = new Vector3(0.00001f, ySpeeds[0] * 10, 0); //Set the speed of the particle
            particles[lastParticleIndex].velocity = velocity;

            // ��ʼ���ϴθı��ٶȵ�ʱ��
            lastChangeTime[lastParticleIndex] = Time.time;
        }

        ps.SetParticles(particles, alive);
    }

    private void Update()
    {
        int alive = ps.GetParticles(particles);

        for (int i = 0; i < alive; i++)
        {
            if (Time.time - lastChangeTime[i] >= 1f / 300f)
            {
                // ����CSV���ݸ���y���ٶ�
                int nextSpeedIndex = (int)((Time.time - lastChangeTime[i]) * 300) % ySpeeds.Count;
                particles[i].velocity = new Vector3(0.00001f, ySpeeds[nextSpeedIndex] * 10, 0);
            }
        }

        ps.SetParticles(particles, alive);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            EmitParticle();
        }
    }
}
