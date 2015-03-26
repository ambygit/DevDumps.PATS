using System;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;

namespace DevDumps.WPFSDK.UI.Key
{
    public abstract class EnumIdResourceKeyBase<TIdSet> : ResourceKey, IEquatable<EnumIdResourceKeyBase<TIdSet>>
    {
        private TIdSet _id;
        private bool _isInitialised;

        static EnumIdResourceKeyBase()
        {
            if (!typeof(TIdSet).IsEnum)
            {
                throw new InvalidProgramException(string.Format("The type of TKeySet should be an enum, but {0} is not an enum.", typeof(TIdSet).FullName));
            }
        }

        /// <summary>
        /// Constructor for Markup Extension with anonymous parameters.
        /// </summary>
        /// <param name="id">The resource Id.</param>
        protected EnumIdResourceKeyBase(TIdSet id)
        {
            _id = id;
            _isInitialised = true;
        }

        /// <summary>
        /// Constructor for Markup Extension with named parameters.
        /// </summary>
        protected EnumIdResourceKeyBase()
        {
        }

        /// <summary>
        /// The key enum value that was used to contruct this ResourceKey object.
        /// </summary>
        [ConstructorArgument("id")]
        public TIdSet Id
        {
            get { return _id; }
            set
            {
                if (_isInitialised)
                    throw new InvalidOperationException("The Id cannot be changed once set.");
                _id = value;
                _isInitialised = true;
            }
        }

        public override Assembly Assembly
        {
            get { return null; }
        }

        public bool Equals(EnumIdResourceKeyBase<TIdSet> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._id, _id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            var @equals = Equals((EnumIdResourceKeyBase<TIdSet>)obj);
            return @equals;
        }

        public override int GetHashCode()
        {
            // ReSharper disable NonReadonlyFieldInGetHashCode
            return (GetType().GetHashCode() * 32) ^ _id.GetHashCode();
            // ReSharper restore NonReadonlyFieldInGetHashCode
        }

        public override string ToString()
        {
            return GetType().FullName + ": " + _id;
        }
    }
}