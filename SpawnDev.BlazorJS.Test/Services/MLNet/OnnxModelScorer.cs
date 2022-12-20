//using Microsoft.ML;
//using Microsoft.ML.Data;
////using BlazorObjectDetectionApp.DataStructures;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Drawing;

//namespace SpawnDev.BlazorJS.Test.Services.MLNet
//{
//    public class ModelInput
//    {
//        [ColumnName(@"Label")]
//        public string Label { get; set; }

//        [ColumnName(@"ImageSource")]
//        public byte[] ImageSource { get; set; }

//    }
//    //public class YoloV3BitmapData
//    //{
//    //    [ColumnName("bitmap")]
//    //    [ImageType(416, 416)]
//    //    public Bitmap Image { get; set; }

//    //    [ColumnName("width")]
//    //    public float ImageWidth => Image.Width;

//    //    [ColumnName("height")]
//    //    public float ImageHeight => Image.Height;
//    //}
//    public class DimensionsBase
//    {
//        public float X { get; set; }
//        public float Y { get; set; }
//        public float Height { get; set; }
//        public float Width { get; set; }
//    }
//    public class YoloBoundingBox
//    {
//        public BoundingBoxDimensions Dimensions { get; set; }

//        public string Label { get; set; }

//        public float Confidence { get; set; }

//        public RectangleF Rect
//        {
//            get { return new RectangleF(Dimensions.X, Dimensions.Y, Dimensions.Width, Dimensions.Height); }
//        }

//        public Color BoxColor { get; set; }
//    }
//    public class BoundingBoxDimensions : DimensionsBase { }
//    public class OnnxModelScorer
//    {
//        // private readonly string imagesFolder;
//        private readonly string modelLocation;
//        private readonly MLContext mlContext;

//        private IList<YoloBoundingBox> _boundingBoxes = new List<YoloBoundingBox>();

//        public ITransformer Model { get; private set; }

//        public OnnxModelScorer(string modelLocation, MLContext mlContext)
//        {
//            //this.imagesFolder = imagesFolder;
//            this.modelLocation = modelLocation;
//            this.mlContext = mlContext;

//            if (Model == null)
//                Model = LoadModel(modelLocation);
//        }
//        public struct ImageNetSettings
//        {
//            public const int imageHeight = 416;
//            public const int imageWidth = 416;
//        }

//        private ITransformer LoadModel(string modelLocation)
//        {
//            var data = mlContext.Data.LoadFromEnumerable(new List<ModelInput>());

//            var pipeline = mlContext.Transforms.ResizeImages(outputColumnName: "image", imageWidth: ImageNetSettings.imageWidth, imageHeight: ImageNetSettings.imageHeight, inputColumnName: "bitmap")
//                .Append(mlContext.Transforms.ExtractPixels(outputColumnName: "image"))
//                .Append(mlContext.Transforms.ApplyOnnxModel(modelFile: modelLocation, outputColumnNames: new[] { TinyYoloModelSettings.ModelOutput }, inputColumnNames: new[] { TinyYoloModelSettings.ModelInput }));
//            var model = pipeline.Fit(data);

//            return model;
//        }

//        private IEnumerable<float[]> PredictDataUsingModel(IDataView testData, ITransformer model)
//        {
//            IDataView scoredData = model.Transform(testData);

//            IEnumerable<float[]> probabilities = scoredData.GetColumn<float[]>(TinyYoloModelSettings.ModelOutput);

//            return probabilities;
//        }

//        public IEnumerable<float[]> Score(IDataView data)
//        {

//            return PredictDataUsingModel(data, Model);
//        }

//        public IEnumerable<float[]> Score(byte[] bitmap)
//        {
//            IDataView imageDataView = new MLContext().Data.LoadFromEnumerable(new List<ModelInput> { new ModelInput()
//            {
//                ImageSource = bitmap
//            }});

//            return PredictDataUsingModel(imageDataView, Model);
//        }
//    }

//    public struct TinyYoloModelSettings
//    {
//        // for checking Tiny yolo2 Model input and  output  parameter names,
//        //you can use tools like Netron, 
//        // which is installed by Visual Studio AI Tools

//        // input tensor name
//        public const string ModelInput = "image";

//        // output tensor name
//        public const string ModelOutput = "grid";
//    }
//}