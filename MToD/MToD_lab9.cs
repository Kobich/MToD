using System;
using System.Collections.Generic;

public class TMember
{
    private int FCoeff;
    private int FDegree;

    public TMember()
    {
        this.FCoeff = 0;
        this.FDegree = 0;
    }

    public TMember(int c, int n)
    {
        this.FCoeff = c;
        if (this.FCoeff == 0)
        {
            this.FDegree = 0;
        }
        else
        {
            this.FDegree = n;
        }
    }

    public int GetDegree()
    {
        return this.FDegree;
    }

    public int GetCoef()
    {
        return this.FCoeff;
    }

    public void SetDegree(int n)
    {
        this.FDegree = n;
    }

    public void SetCoef(int c)
    {
        this.FCoeff = c;
    }

    public bool IsEqual(TMember q)
    {
        return this.FCoeff == q.FCoeff && this.FDegree == q.FDegree;
    }

    public TMember Diff()
    {
        int newCoef = this.FCoeff * this.FDegree;
        int newDegree = this.FDegree - 1;
        return new TMember(newCoef, newDegree);
    }

    public int Calculate(int x)
    {
        return this.FCoeff * (int)Math.Pow(x, this.FDegree);
    }

    public string GetString()
    {
        return $"{this.FCoeff}*x^{this.FDegree}";
    }
}


public class TPoly
{
    private List<TMember> polynom;

    public TPoly()
    {
        this.polynom = new List<TMember>();
    }

    public TPoly(int c, int n)
    {
        this.polynom = new List<TMember> { new TMember(c, n) };
    }

    public int MaxDegree()
    {
        int maxDegree = this.polynom[0].GetDegree();
        foreach (var member in this.polynom)
        {
            int a = member.GetDegree();
            if (a > maxDegree) maxDegree = a;
        }
        return maxDegree;
    }

    public int DegreeCoef(int n)
    {
        foreach (var member in this.polynom)
        {
            if (member.GetDegree() == n) return member.GetCoef();
        }
        return 0;
    }

    public void Clear()
    {
        this.polynom.Clear();
    }

    public TPoly Add(TPoly q)
    {
        TPoly res = new TPoly();
        res.polynom.AddRange(this.polynom);

        for (int i = 0; i < q.polynom.Count; i++)
        {
            var memberQ = q.polynom[i];
            bool flagAdd = false;
            for (int j = 0; j < res.polynom.Count; j++)
            {
                var memberThis = res.polynom[j];
                if (memberQ.GetDegree() == memberThis.GetDegree())
                {
                    flagAdd = true;
                    res.polynom[j] = new TMember(memberQ.GetCoef() + memberThis.GetCoef(), memberQ.GetDegree());
                    break;
                }
            }
            if (!flagAdd)
            {
                res.polynom.Add(new TMember(memberQ.GetCoef(), memberQ.GetDegree()));
            }
        }
        return res;
    }


    public TPoly Multy(TPoly q)
    {
        TPoly res = new TPoly();
        foreach (var memberQ in q.polynom)
        {
            foreach (var memberThis in this.polynom)
            {
                res = res.Add(new TPoly(memberQ.GetCoef() * memberThis.GetCoef(), memberQ.GetDegree() + memberThis.GetDegree()));
            }
        }
        return res;
    }

    public TPoly Sub(TPoly q)
    {
        TPoly res = new TPoly();
        res.polynom.AddRange(this.polynom);

        for (int i = 0; i < q.polynom.Count; i++)
        {
            var memberQ = q.polynom[i];
            bool flagAdd = false;
            for (int j = 0; j < res.polynom.Count; j++)
            {
                var memberThis = res.polynom[j];
                if (memberQ.GetDegree() == memberThis.GetDegree())
                {
                    flagAdd = true;
                    res.polynom[j] = new TMember(-memberQ.GetCoef() + memberThis.GetCoef(), memberQ.GetDegree());
                    break;
                }
            }
            if (!flagAdd)
            {
                res.polynom.Add(new TMember(-memberQ.GetCoef(), memberQ.GetDegree()));
            }
        }
        return res;
    }


    public TPoly Negative()
    {
        TPoly res = new TPoly();
        foreach (var memberThis in this.polynom)
        {
            res.polynom.Add(new TMember(-memberThis.GetCoef(), memberThis.GetDegree()));
        }
        return res;
    }

    public bool IsEqual(TPoly q)
    {
        if (this.polynom.Count != q.polynom.Count)
        {
            return false;
        }

        foreach (var member in this.polynom)
        {
            bool foundFlag = false;
            foreach (var otherMember in q.polynom)
            {
                if (member.IsEqual(otherMember))
                {
                    foundFlag = true;
                    break;
                }
            }
            if (!foundFlag)
            {
                return false;
            }
        }
        return true;
    }

    public TPoly Diff()
    {
        TPoly res = new TPoly();
        foreach (var member in this.polynom)
        {
            res.polynom.Add(member.Diff());
        }
        return res;
    }

    public int Calculate(int x)
    {
        int res = 0;
        foreach (var member in this.polynom)
        {
            res += member.Calculate(x);
        }
        return res;
    }

    public TMember El(int i)
    {
        if (i >= polynom.Count || i < 0)
        {
            throw new ArgumentOutOfRangeException($"Index {i} out of range");
        }
        return polynom[i];
    }

    public string GetString()
    {
        string result = string.Join(" ", this.polynom.ConvertAll(member => member.GetString()));
        return result.TrimEnd();
    }
}

