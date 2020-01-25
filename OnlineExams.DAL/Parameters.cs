using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExams.DAL
{
    public class Parameters : IEnumerable
    {
        ArrayList _parameters = new ArrayList();

        public Parameters()
        {

        }

        public void Add(Parameter OParameter)
        {
            try
            {
                _parameters.Add(OParameter);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().Name + "::" + ex.Message);
            }

        }

        public Parameter this[int i]
        {
            get
            {

                try
                {
                    if (i < 0 || i >= _parameters.Count)
                    {
                        return null;
                    }
                    else
                    {
                        return (Parameter)_parameters[i];
                    }


                }
                catch (Exception ex)
                {
                    throw new Exception(
                                        System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "::" +
                                        System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "::" +
                                        System.Reflection.MethodInfo.GetCurrentMethod().Name + "::" + ex.Message);
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new ParameterEnumerator(this);
        }

        public class ParameterEnumerator : IEnumerator
        {
            Parameters _paramCollection;
            int _location;

            public ParameterEnumerator(Parameters parameters)
            {
                _paramCollection = parameters;
                _location = -1;

            }

            public void Reset()
            {
                _location = -1;
            }

            public object Current
            {

                get
                {

                    if (_location < 0 || _location >= _paramCollection._parameters.Count)
                    {
                        throw new InvalidOperationException();
                    }
                    else
                    {
                        return _paramCollection._parameters[_location];
                    }
                }
            }

            public bool MoveNext()
            {

                _location++;
                if (_location >= _paramCollection._parameters.Count)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }
    }
}
