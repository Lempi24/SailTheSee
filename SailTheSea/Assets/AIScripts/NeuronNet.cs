using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MathNet.Numerics.LinearAlgebra;
using System;

using Random = UnityEngine.Random;

public class NeuronNet : MonoBehaviour
{
    public Matrix<float> inputLayer;

    public List<Matrix<float>> hiddenLayers;

    public Matrix<float> outputLayer;

    //Macierz dla wag
    public List<Matrix<float>> weights;

    //Macierz dla Bias�w 
    public List<float> biases;

    public float fitness;

    private void Awake()
    {
        inputLayer = Matrix<float>.Build.Dense(1, 5);
        hiddenLayers = new List<Matrix<float>>();
        outputLayer = Matrix<float>.Build.Dense(1, 2);
        weights = new List<Matrix<float>>();
        biases = new List<float>();
    }

    public void Initialise(int hiddenLayerCount, int hiddenNeuronCount)
    {
        inputLayer.Clear();
        hiddenLayers.Clear();
        outputLayer.Clear();
        weights.Clear();
        biases.Clear();

        for (int i = 0; i < hiddenLayerCount + 1; i++)
        {
            Matrix<float> f = Matrix<float>.Build.Dense(1, hiddenNeuronCount);

            hiddenLayers.Add(f);

            //Biasy
            biases.Add(Random.Range(-1f, 1f));

            //Wagi
            if (i == 0)
            {
                Matrix<float> inputToH1 = Matrix<float>.Build.Dense(5, hiddenNeuronCount);
                weights.Add(inputToH1);
            }
            else
            {
                Matrix<float> HiddenToHidden = Matrix<float>.Build.Dense(hiddenNeuronCount, hiddenNeuronCount);
                weights.Add(HiddenToHidden);
            }
        }

        Matrix<float> OutputWeight = Matrix<float>.Build.Dense(hiddenNeuronCount, 1);

        weights.Add(OutputWeight);
        biases.Add(Random.Range(-1f, 1f));

        RandomiseWeights();
    }

    public NeuronNet InitialiseCopy(int hiddenLayerCount, int hiddenNeuronCount)
    {
        NeuronNet n = gameObject.AddComponent<NeuronNet>();

        List<Matrix<float>> newWeights = new List<Matrix<float>>();

        for (int i = 0; i < weights.Count; i++)
        {
            Matrix<float> currentWeight = Matrix<float>.Build.Dense(weights[i].RowCount, weights[i].ColumnCount);

            for (int x = 0; x < currentWeight.RowCount; x++)
            {
                for (int y = 0; y < currentWeight.ColumnCount; y++)
                {
                    currentWeight[x, y] = weights[i][x, y];
                }
            }

            newWeights.Add(currentWeight);
        }

        List<float> newBiases = new List<float>();

        newBiases.AddRange(biases);

        n.weights = newWeights;
        n.biases = newBiases;

        n.InitialiseHidden(hiddenLayerCount, hiddenNeuronCount);

        return n;
    }

    public void InitialiseHidden(int hiddenLayerCount, int hiddenNeuronCount)
    {
        inputLayer.Clear();
        hiddenLayers.Clear();
        outputLayer.Clear();

        for (int i = 0; i < hiddenLayerCount + 1; i++)
        {
            Matrix<float> newHiddenLayer = Matrix<float>.Build.Dense(1, hiddenNeuronCount);
            hiddenLayers.Add(newHiddenLayer);
        }
    }

    public void RandomiseWeights()
    {
        for (int i = 0; i < weights.Count; i++)
        {
            for (int x = 0; x < weights[i].RowCount; x++)
            {
                for (int y = 0; y < weights[i].ColumnCount; y++)
                {
                    weights[i][x, y] = Random.Range(-1f, 1f);
                }
            }
        }
    }

    public float RunNetwork(float a, float b, float c, float d, float e)
    {
        inputLayer[0, 0] = a;
        inputLayer[0, 1] = b;
        inputLayer[0, 2] = c;
        inputLayer[0, 3] = d;
        inputLayer[0, 4] = e;

        inputLayer = inputLayer.PointwiseTanh();

        hiddenLayers[0] = ((inputLayer * weights[0]) + biases[0]).PointwiseTanh();

        for (int i = 1; i < hiddenLayers.Count; i++)
        {
            hiddenLayers[i] = ((hiddenLayers[i - 1] * weights[i]) + biases[i]).PointwiseTanh();
        }

        outputLayer = ((hiddenLayers[hiddenLayers.Count - 1] * weights[weights.Count - 1]) + biases[biases.Count - 1]).PointwiseTanh();

        //Pierwszy output to up a drugi output to turn
        return ((float)Math.Tanh(outputLayer[0, 0]));
    }
}
