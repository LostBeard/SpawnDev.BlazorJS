//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Diagnostics.CodeAnalysis;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SpawnDev.BlazorJS {
//    internal class PropertyOverridingTypeDescriptionProvider : TypeDescriptionProvider {
//        private readonly Dictionary<Type, ICustomTypeDescriptor> _descriptorCache = new Dictionary<Type, ICustomTypeDescriptor>();

//        TypeDescriptionProvider _parentProvider;

//        public PropertyOverridingTypeDescriptionProvider(TypeDescriptionProvider parentProvider) : base(parentProvider) {
//            _parentProvider = parentProvider;
//        }
//        protected override IExtenderProvider[] GetExtenderProviders(object instance) {
//            return base.GetExtenderProviders(instance);
//        }
//        public override bool IsSupportedType(Type type) {
//            return base.IsSupportedType(type);
//        }

//        public override Type GetRuntimeType(Type reflectionType) {
//            return base.GetRuntimeType(reflectionType);
//        }

//        [return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)]
//        public override Type GetReflectionType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)] Type objectType, object? instance) {
//            return base.GetReflectionType(objectType, instance);
//        }

//        public override object? CreateInstance(IServiceProvider? provider, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type objectType, Type[]? argTypes, object?[]? args) {

//            return base.CreateInstance(provider, objectType, argTypes, args);
//        }

//        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance) {
//            lock (_descriptorCache) {
//                ICustomTypeDescriptor returnDescriptor;
//                if (!_descriptorCache.TryGetValue(objectType, out returnDescriptor)) {
//                    returnDescriptor = CreateTypeDescriptor(objectType);
//                }
//                return returnDescriptor;
//            }
//        }

//        private ICustomTypeDescriptor CreateTypeDescriptor(Type targetType) {
//            var descriptor = base.GetTypeDescriptor(targetType, null);
//            _descriptorCache.Add(targetType, descriptor);
//            var ctd = new PropertyOverridingTypeDescriptor(descriptor, targetType);
//            _descriptorCache[targetType] = ctd;
//            return ctd;
//        }
//    }
//    internal class PropertyOverridingTypeDescriptor : CustomTypeDescriptor {
//        private readonly ICustomTypeDescriptor _parent;
//        private readonly PropertyDescriptorCollection _propertyCollection;
//        private readonly Type _objectType;

//        public PropertyOverridingTypeDescriptor(ICustomTypeDescriptor parent, Type objectType)
//            : base(parent) {
//            _parent = parent;
//            _objectType = objectType;
//            _propertyCollection = BuildPropertyCollection();
//        }

//        private PropertyDescriptorCollection BuildPropertyCollection() {
//            var isChanged = false;
//            var parentProperties = _parent.GetProperties();

//            return parentProperties;
//            //var pdl = new PropertyDescriptor[parentProperties.Count];
//            //var index = 0;
//            //foreach (var pd in parentProperties.OfType<PropertyDescriptor>()) {
//            //    var pdReplaced = pd;
//            //    if (_condition(pd)) {
//            //        pdReplaced = _propertyCreator(pd, _objectType);
//            //    }
//            //    if (!ReferenceEquals(pdReplaced, pd)) isChanged = true;
//            //    pdl[index++] = pdReplaced;
//            //}
//            //return !isChanged ? parentProperties : new PropertyDescriptorCollection(pdl);
//        }

//        public override string? GetComponentName() {
//            var ret = base.GetComponentName();
//            return ret;
//        }

//        public override TypeConverter? GetConverter() {
//            var ret = base.GetConverter();
//            return ret;
//        }

//        public override AttributeCollection GetAttributes() {
//            var ret = base.GetAttributes();
//            return ret;
//        }

//        public override string? GetClassName() {
//            var ret = base.GetClassName();
//            return ret;
//        }

//        public override object GetPropertyOwner(PropertyDescriptor pd) {
//            var o = base.GetPropertyOwner(pd);
//            return o ?? this;
//        }

//        public override PropertyDescriptorCollection GetProperties() {
//            return _propertyCollection;
//        }
//        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes) {
//            return _propertyCollection;
//        }

//        public static void ChangeTypeProperties(Type modifiedType) {
//            // Get the current TypeDescriptionProvider
//            var curProvider = TypeDescriptor.GetProvider(modifiedType);
//            // Create a replacement provider, pass in the parent, this is important
//            var replaceProvider = new PropertyOverridingTypeDescriptionProvider(curProvider);
//            // Finally we replace the TypeDescriptionProvider
//            TypeDescriptor.AddProvider(replaceProvider, modifiedType);
//        }
//    }
//}
