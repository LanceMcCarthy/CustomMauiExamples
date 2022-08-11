using Grpc.Core;
using pb = Google.Protobuf;
using pbc = Google.Protobuf.Collections;
using pbr = Google.Protobuf.Reflection;
using scg = System.Collections.Generic;

namespace RealtimeDataSystem.Maui.Grpc;

public static partial class Stock
{
    static readonly string __ServiceName = "stock.Stock";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, SerializationContext context)
    {
#if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
        if (message is global::Google.Protobuf.IBufferMessage)
        {
            context.SetPayloadLength(message.CalculateSize());
            global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
            context.Complete();
            return;
        }
#endif
        context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
        public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
#if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
        if (__Helper_MessageCache<T>.IsBufferMessage)
        {
            return parser.ParseFrom(context.PayloadAsReadOnlySequence());
        }
#endif
        return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly Marshaller<global::RealtimeDataSystem.Maui.Grpc.QuoteRequest> __Marshaller_stock_QuoteRequest = Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::RealtimeDataSystem.Maui.Grpc.QuoteRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly Marshaller<global::RealtimeDataSystem.Maui.Grpc.QuoteReply> __Marshaller_stock_QuoteReply = Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::RealtimeDataSystem.Maui.Grpc.QuoteReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly Marshaller<global::RealtimeDataSystem.Maui.Grpc.BuyRequest> __Marshaller_stock_BuyRequest = Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::RealtimeDataSystem.Maui.Grpc.BuyRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly Marshaller<global::RealtimeDataSystem.Maui.Grpc.TransactionReply> __Marshaller_stock_TransactionReply = Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::RealtimeDataSystem.Maui.Grpc.TransactionReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly Marshaller<global::RealtimeDataSystem.Maui.Grpc.SellRequest> __Marshaller_stock_SellRequest = Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::RealtimeDataSystem.Maui.Grpc.SellRequest.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly Method<global::RealtimeDataSystem.Maui.Grpc.QuoteRequest, global::RealtimeDataSystem.Maui.Grpc.QuoteReply> __Method_GetQuote = new Method<global::RealtimeDataSystem.Maui.Grpc.QuoteRequest, global::RealtimeDataSystem.Maui.Grpc.QuoteReply>(
        MethodType.Unary,
        __ServiceName,
        "GetQuote",
        __Marshaller_stock_QuoteRequest,
        __Marshaller_stock_QuoteReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly Method<global::RealtimeDataSystem.Maui.Grpc.BuyRequest, global::RealtimeDataSystem.Maui.Grpc.TransactionReply> __Method_BuyOrder = new Method<global::RealtimeDataSystem.Maui.Grpc.BuyRequest, global::RealtimeDataSystem.Maui.Grpc.TransactionReply>(
        MethodType.Unary,
        __ServiceName,
        "BuyOrder",
        __Marshaller_stock_BuyRequest,
        __Marshaller_stock_TransactionReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly Method<global::RealtimeDataSystem.Maui.Grpc.SellRequest, global::RealtimeDataSystem.Maui.Grpc.TransactionReply> __Method_SellOrder = new Method<global::RealtimeDataSystem.Maui.Grpc.SellRequest, global::RealtimeDataSystem.Maui.Grpc.TransactionReply>(
        MethodType.Unary,
        __ServiceName,
        "SellOrder",
        __Marshaller_stock_SellRequest,
        __Marshaller_stock_TransactionReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
        get { return global::RealtimeDataSystem.Maui.Grpc.StockReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for Stock</summary>
    public partial class StockClient : ClientBase<StockClient>
    {
        /// <summary>Creates a new client for Stock</summary>
        /// <param name="channel">The channel to use to make remote calls.</param>
        [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        public StockClient(ChannelBase channel) : base(channel)
        {
        }
        /// <summary>Creates a new client for Stock that uses a custom <c>CallInvoker</c>.</summary>
        /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
        [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        public StockClient(CallInvoker callInvoker) : base(callInvoker)
        {
        }
        /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
        [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        protected StockClient() : base()
        {
        }
        /// <summary>Protected constructor to allow creation of configured clients.</summary>
        /// <param name="configuration">The client configuration.</param>
        [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        protected StockClient(ClientBaseConfiguration configuration) : base(configuration)
        {
        }

        [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        public virtual global::RealtimeDataSystem.Maui.Grpc.QuoteReply GetQuote(global::RealtimeDataSystem.Maui.Grpc.QuoteRequest request, Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            return GetQuote(request, new CallOptions(headers, deadline, cancellationToken));
        }
        [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        public virtual global::RealtimeDataSystem.Maui.Grpc.QuoteReply GetQuote(global::RealtimeDataSystem.Maui.Grpc.QuoteRequest request, CallOptions options)
        {
            return CallInvoker.BlockingUnaryCall(__Method_GetQuote, null, options, request);
        }
        [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        public virtual AsyncUnaryCall<global::RealtimeDataSystem.Maui.Grpc.QuoteReply> GetQuoteAsync(global::RealtimeDataSystem.Maui.Grpc.QuoteRequest request, Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            return GetQuoteAsync(request, new CallOptions(headers, deadline, cancellationToken));
        }
        [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        public virtual AsyncUnaryCall<global::RealtimeDataSystem.Maui.Grpc.QuoteReply> GetQuoteAsync(global::RealtimeDataSystem.Maui.Grpc.QuoteRequest request, CallOptions options)
        {
            return CallInvoker.AsyncUnaryCall(__Method_GetQuote, null, options, request);
        }
        [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        public virtual global::RealtimeDataSystem.Maui.Grpc.TransactionReply BuyOrder(global::RealtimeDataSystem.Maui.Grpc.BuyRequest request, Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            return BuyOrder(request, new CallOptions(headers, deadline, cancellationToken));
        }
        [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        public virtual global::RealtimeDataSystem.Maui.Grpc.TransactionReply BuyOrder(global::RealtimeDataSystem.Maui.Grpc.BuyRequest request, CallOptions options)
        {
            return CallInvoker.BlockingUnaryCall(__Method_BuyOrder, null, options, request);
        }
        [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        public virtual AsyncUnaryCall<global::RealtimeDataSystem.Maui.Grpc.TransactionReply> BuyOrderAsync(global::RealtimeDataSystem.Maui.Grpc.BuyRequest request, Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            return BuyOrderAsync(request, new CallOptions(headers, deadline, cancellationToken));
        }
        [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        public virtual AsyncUnaryCall<global::RealtimeDataSystem.Maui.Grpc.TransactionReply> BuyOrderAsync(global::RealtimeDataSystem.Maui.Grpc.BuyRequest request, CallOptions options)
        {
            return CallInvoker.AsyncUnaryCall(__Method_BuyOrder, null, options, request);
        }
        [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        public virtual global::RealtimeDataSystem.Maui.Grpc.TransactionReply SellOrder(global::RealtimeDataSystem.Maui.Grpc.SellRequest request, Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            return SellOrder(request, new CallOptions(headers, deadline, cancellationToken));
        }
        [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        public virtual global::RealtimeDataSystem.Maui.Grpc.TransactionReply SellOrder(global::RealtimeDataSystem.Maui.Grpc.SellRequest request, CallOptions options)
        {
            return CallInvoker.BlockingUnaryCall(__Method_SellOrder, null, options, request);
        }
        [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        public virtual AsyncUnaryCall<global::RealtimeDataSystem.Maui.Grpc.TransactionReply> SellOrderAsync(global::RealtimeDataSystem.Maui.Grpc.SellRequest request, Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            return SellOrderAsync(request, new CallOptions(headers, deadline, cancellationToken));
        }
        [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        public virtual AsyncUnaryCall<global::RealtimeDataSystem.Maui.Grpc.TransactionReply> SellOrderAsync(global::RealtimeDataSystem.Maui.Grpc.SellRequest request, CallOptions options)
        {
            return CallInvoker.AsyncUnaryCall(__Method_SellOrder, null, options, request);
        }
        /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
        [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
        protected override StockClient NewInstance(ClientBaseConfiguration configuration)
        {
            return new StockClient(configuration);
        }
    }

}

/// <summary>Holder for reflection information generated from Protos/stock.proto</summary>
public static partial class StockReflection
{

    #region Descriptor
    /// <summary>File descriptor for Protos/stock.proto</summary>
    public static pbr::FileDescriptor Descriptor
    {
        get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static StockReflection()
    {
        byte[] descriptorData = global::System.Convert.FromBase64String(
            string.Concat(
              "ChJQcm90b3Mvc3RvY2sucHJvdG8SBXN0b2NrGh9nb29nbGUvcHJvdG9idWYv",
              "dGltZXN0YW1wLnByb3RvIh4KDFF1b3RlUmVxdWVzdBIOCgZ0aWNrZXIYASAB",
              "KAkiWwoKUXVvdGVSZXBseRIOCgZ0aWNrZXIYASABKAkSDQoFcXVvdGUYAiAB",
              "KAESLgoKcXVvdGVfdGltZRgDIAEoCzIaLmdvb2dsZS5wcm90b2J1Zi5UaW1l",
              "c3RhbXAiPQoKQnV5UmVxdWVzdBIOCgZ0aWNrZXIYASABKAkSDQoFcXVvdGUY",
              "AiABKAESEAoIcXVhbnRpdHkYAyABKAUiPgoLU2VsbFJlcXVlc3QSDgoGdGlj",
              "a2VyGAEgASgJEg0KBXF1b3RlGAIgASgBEhAKCHF1YW50aXR5GAMgASgFImIK",
              "EFRyYW5zYWN0aW9uUmVwbHkSDgoGdGlja2VyGAEgASgJEhAKCHF1YW50aXR5",
              "GAIgASgFEh0KFXRyYW5zYWN0aW9uX2NvbmZpcm1lZBgDIAEoCBINCgVwcmlj",
              "ZRgEIAEoATKtAQoFU3RvY2sSMgoIR2V0UXVvdGUSEy5zdG9jay5RdW90ZVJl",
              "cXVlc3QaES5zdG9jay5RdW90ZVJlcGx5EjYKCEJ1eU9yZGVyEhEuc3RvY2su",
              "QnV5UmVxdWVzdBoXLnN0b2NrLlRyYW5zYWN0aW9uUmVwbHkSOAoJU2VsbE9y",
              "ZGVyEhIuc3RvY2suU2VsbFJlcXVlc3QaFy5zdG9jay5UcmFuc2FjdGlvblJl",
              "cGx5QhqqAhdSZWFsdGltZURhdGFTeXN0ZW0uTWF1aWIGcHJvdG8z"));
        descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
            new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
            new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::RealtimeDataSystem.Maui.Grpc.QuoteRequest), global::RealtimeDataSystem.Maui.Grpc.QuoteRequest.Parser, new[]{ "Ticker" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::RealtimeDataSystem.Maui.Grpc.QuoteReply), global::RealtimeDataSystem.Maui.Grpc.QuoteReply.Parser, new[]{ "Ticker", "Quote", "QuoteTime" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::RealtimeDataSystem.Maui.Grpc.BuyRequest), global::RealtimeDataSystem.Maui.Grpc.BuyRequest.Parser, new[]{ "Ticker", "Quote", "Quantity" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::RealtimeDataSystem.Maui.Grpc.SellRequest), global::RealtimeDataSystem.Maui.Grpc.SellRequest.Parser, new[]{ "Ticker", "Quote", "Quantity" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::RealtimeDataSystem.Maui.Grpc.TransactionReply), global::RealtimeDataSystem.Maui.Grpc.TransactionReply.Parser, new[]{ "Ticker", "Quantity", "TransactionConfirmed", "Price" }, null, null, null, null)
            }));
    }
    #endregion

}

public sealed partial class QuoteRequest : pb::IMessage<QuoteRequest>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
    private static readonly pb::MessageParser<QuoteRequest> _parser = new pb::MessageParser<QuoteRequest>(() => new QuoteRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<QuoteRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor
    {
        get { return global::RealtimeDataSystem.Maui.Grpc.StockReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor
    {
        get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public QuoteRequest()
    {
        OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public QuoteRequest(QuoteRequest other) : this()
    {
        ticker_ = other.ticker_;
        _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public QuoteRequest Clone()
    {
        return new QuoteRequest(this);
    }

    /// <summary>Field number for the "ticker" field.</summary>
    public const int TickerFieldNumber = 1;
    private string ticker_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Ticker
    {
        get { return ticker_; }
        set
        {
            ticker_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
        }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other)
    {
        return Equals(other as QuoteRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(QuoteRequest other)
    {
        if (ReferenceEquals(other, null))
        {
            return false;
        }
        if (ReferenceEquals(other, this))
        {
            return true;
        }
        if (Ticker != other.Ticker) return false;
        return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode()
    {
        int hash = 1;
        if (Ticker.Length != 0) hash ^= Ticker.GetHashCode();
        if (_unknownFields != null)
        {
            hash ^= _unknownFields.GetHashCode();
        }
        return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString()
    {
        return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output)
    {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        output.WriteRawMessage(this);
#else
      if (Ticker.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Ticker);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
#endif
    }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output)
    {
        if (Ticker.Length != 0)
        {
            output.WriteRawTag(10);
            output.WriteString(Ticker);
        }
        if (_unknownFields != null)
        {
            _unknownFields.WriteTo(ref output);
        }
    }
#endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize()
    {
        int size = 0;
        if (Ticker.Length != 0)
        {
            size += 1 + pb::CodedOutputStream.ComputeStringSize(Ticker);
        }
        if (_unknownFields != null)
        {
            size += _unknownFields.CalculateSize();
        }
        return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(QuoteRequest other)
    {
        if (other == null)
        {
            return;
        }
        if (other.Ticker.Length != 0)
        {
            Ticker = other.Ticker;
        }
        _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input)
    {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        input.ReadRawMessage(this);
#else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Ticker = input.ReadString();
            break;
          }
        }
      }
#endif
    }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input)
    {
        uint tag;
        while ((tag = input.ReadTag()) != 0)
        {
            switch (tag)
            {
                default:
                    _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
                    break;
                case 10:
                    {
                        Ticker = input.ReadString();
                        break;
                    }
            }
        }
    }
#endif

}

public sealed partial class QuoteReply : pb::IMessage<QuoteReply>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
    private static readonly pb::MessageParser<QuoteReply> _parser = new pb::MessageParser<QuoteReply>(() => new QuoteReply());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<QuoteReply> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor
    {
        get { return global::RealtimeDataSystem.Maui.Grpc.StockReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor
    {
        get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public QuoteReply()
    {
        OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public QuoteReply(QuoteReply other) : this()
    {
        ticker_ = other.ticker_;
        quote_ = other.quote_;
        quoteTime_ = other.quoteTime_ != null ? other.quoteTime_.Clone() : null;
        _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public QuoteReply Clone()
    {
        return new QuoteReply(this);
    }

    /// <summary>Field number for the "ticker" field.</summary>
    public const int TickerFieldNumber = 1;
    private string ticker_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Ticker
    {
        get { return ticker_; }
        set
        {
            ticker_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
        }
    }

    /// <summary>Field number for the "quote" field.</summary>
    public const int QuoteFieldNumber = 2;
    private double quote_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public double Quote
    {
        get { return quote_; }
        set
        {
            quote_ = value;
        }
    }

    /// <summary>Field number for the "quote_time" field.</summary>
    public const int QuoteTimeFieldNumber = 3;
    private global::Google.Protobuf.WellKnownTypes.Timestamp quoteTime_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Google.Protobuf.WellKnownTypes.Timestamp QuoteTime
    {
        get { return quoteTime_; }
        set
        {
            quoteTime_ = value;
        }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other)
    {
        return Equals(other as QuoteReply);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(QuoteReply other)
    {
        if (ReferenceEquals(other, null))
        {
            return false;
        }
        if (ReferenceEquals(other, this))
        {
            return true;
        }
        if (Ticker != other.Ticker) return false;
        if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Quote, other.Quote)) return false;
        if (!object.Equals(QuoteTime, other.QuoteTime)) return false;
        return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode()
    {
        int hash = 1;
        if (Ticker.Length != 0) hash ^= Ticker.GetHashCode();
        if (Quote != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Quote);
        if (quoteTime_ != null) hash ^= QuoteTime.GetHashCode();
        if (_unknownFields != null)
        {
            hash ^= _unknownFields.GetHashCode();
        }
        return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString()
    {
        return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output)
    {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        output.WriteRawMessage(this);
#else
      if (Ticker.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Ticker);
      }
      if (Quote != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(Quote);
      }
      if (quoteTime_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(QuoteTime);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
#endif
    }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output)
    {
        if (Ticker.Length != 0)
        {
            output.WriteRawTag(10);
            output.WriteString(Ticker);
        }
        if (Quote != 0D)
        {
            output.WriteRawTag(17);
            output.WriteDouble(Quote);
        }
        if (quoteTime_ != null)
        {
            output.WriteRawTag(26);
            output.WriteMessage(QuoteTime);
        }
        if (_unknownFields != null)
        {
            _unknownFields.WriteTo(ref output);
        }
    }
#endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize()
    {
        int size = 0;
        if (Ticker.Length != 0)
        {
            size += 1 + pb::CodedOutputStream.ComputeStringSize(Ticker);
        }
        if (Quote != 0D)
        {
            size += 1 + 8;
        }
        if (quoteTime_ != null)
        {
            size += 1 + pb::CodedOutputStream.ComputeMessageSize(QuoteTime);
        }
        if (_unknownFields != null)
        {
            size += _unknownFields.CalculateSize();
        }
        return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(QuoteReply other)
    {
        if (other == null)
        {
            return;
        }
        if (other.Ticker.Length != 0)
        {
            Ticker = other.Ticker;
        }
        if (other.Quote != 0D)
        {
            Quote = other.Quote;
        }
        if (other.quoteTime_ != null)
        {
            if (quoteTime_ == null)
            {
                QuoteTime = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            QuoteTime.MergeFrom(other.QuoteTime);
        }
        _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input)
    {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        input.ReadRawMessage(this);
#else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Ticker = input.ReadString();
            break;
          }
          case 17: {
            Quote = input.ReadDouble();
            break;
          }
          case 26: {
            if (quoteTime_ == null) {
              QuoteTime = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(QuoteTime);
            break;
          }
        }
      }
#endif
    }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input)
    {
        uint tag;
        while ((tag = input.ReadTag()) != 0)
        {
            switch (tag)
            {
                default:
                    _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
                    break;
                case 10:
                    {
                        Ticker = input.ReadString();
                        break;
                    }
                case 17:
                    {
                        Quote = input.ReadDouble();
                        break;
                    }
                case 26:
                    {
                        if (quoteTime_ == null)
                        {
                            QuoteTime = new global::Google.Protobuf.WellKnownTypes.Timestamp();
                        }
                        input.ReadMessage(QuoteTime);
                        break;
                    }
            }
        }
    }
#endif

}

public sealed partial class BuyRequest : pb::IMessage<BuyRequest>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
    private static readonly pb::MessageParser<BuyRequest> _parser = new pb::MessageParser<BuyRequest>(() => new BuyRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<BuyRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor
    {
        get { return global::RealtimeDataSystem.Maui.Grpc.StockReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor
    {
        get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public BuyRequest()
    {
        OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public BuyRequest(BuyRequest other) : this()
    {
        ticker_ = other.ticker_;
        quote_ = other.quote_;
        quantity_ = other.quantity_;
        _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public BuyRequest Clone()
    {
        return new BuyRequest(this);
    }

    /// <summary>Field number for the "ticker" field.</summary>
    public const int TickerFieldNumber = 1;
    private string ticker_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Ticker
    {
        get { return ticker_; }
        set
        {
            ticker_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
        }
    }

    /// <summary>Field number for the "quote" field.</summary>
    public const int QuoteFieldNumber = 2;
    private double quote_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public double Quote
    {
        get { return quote_; }
        set
        {
            quote_ = value;
        }
    }

    /// <summary>Field number for the "quantity" field.</summary>
    public const int QuantityFieldNumber = 3;
    private int quantity_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Quantity
    {
        get { return quantity_; }
        set
        {
            quantity_ = value;
        }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other)
    {
        return Equals(other as BuyRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(BuyRequest other)
    {
        if (ReferenceEquals(other, null))
        {
            return false;
        }
        if (ReferenceEquals(other, this))
        {
            return true;
        }
        if (Ticker != other.Ticker) return false;
        if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Quote, other.Quote)) return false;
        if (Quantity != other.Quantity) return false;
        return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode()
    {
        int hash = 1;
        if (Ticker.Length != 0) hash ^= Ticker.GetHashCode();
        if (Quote != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Quote);
        if (Quantity != 0) hash ^= Quantity.GetHashCode();
        if (_unknownFields != null)
        {
            hash ^= _unknownFields.GetHashCode();
        }
        return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString()
    {
        return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output)
    {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        output.WriteRawMessage(this);
#else
      if (Ticker.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Ticker);
      }
      if (Quote != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(Quote);
      }
      if (Quantity != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Quantity);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
#endif
    }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output)
    {
        if (Ticker.Length != 0)
        {
            output.WriteRawTag(10);
            output.WriteString(Ticker);
        }
        if (Quote != 0D)
        {
            output.WriteRawTag(17);
            output.WriteDouble(Quote);
        }
        if (Quantity != 0)
        {
            output.WriteRawTag(24);
            output.WriteInt32(Quantity);
        }
        if (_unknownFields != null)
        {
            _unknownFields.WriteTo(ref output);
        }
    }
#endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize()
    {
        int size = 0;
        if (Ticker.Length != 0)
        {
            size += 1 + pb::CodedOutputStream.ComputeStringSize(Ticker);
        }
        if (Quote != 0D)
        {
            size += 1 + 8;
        }
        if (Quantity != 0)
        {
            size += 1 + pb::CodedOutputStream.ComputeInt32Size(Quantity);
        }
        if (_unknownFields != null)
        {
            size += _unknownFields.CalculateSize();
        }
        return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(BuyRequest other)
    {
        if (other == null)
        {
            return;
        }
        if (other.Ticker.Length != 0)
        {
            Ticker = other.Ticker;
        }
        if (other.Quote != 0D)
        {
            Quote = other.Quote;
        }
        if (other.Quantity != 0)
        {
            Quantity = other.Quantity;
        }
        _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input)
    {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        input.ReadRawMessage(this);
#else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Ticker = input.ReadString();
            break;
          }
          case 17: {
            Quote = input.ReadDouble();
            break;
          }
          case 24: {
            Quantity = input.ReadInt32();
            break;
          }
        }
      }
#endif
    }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input)
    {
        uint tag;
        while ((tag = input.ReadTag()) != 0)
        {
            switch (tag)
            {
                default:
                    _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
                    break;
                case 10:
                    {
                        Ticker = input.ReadString();
                        break;
                    }
                case 17:
                    {
                        Quote = input.ReadDouble();
                        break;
                    }
                case 24:
                    {
                        Quantity = input.ReadInt32();
                        break;
                    }
            }
        }
    }
#endif

}

public sealed partial class SellRequest : pb::IMessage<SellRequest>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
    private static readonly pb::MessageParser<SellRequest> _parser = new pb::MessageParser<SellRequest>(() => new SellRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<SellRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor
    {
        get { return global::RealtimeDataSystem.Maui.Grpc.StockReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor
    {
        get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SellRequest()
    {
        OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SellRequest(SellRequest other) : this()
    {
        ticker_ = other.ticker_;
        quote_ = other.quote_;
        quantity_ = other.quantity_;
        _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SellRequest Clone()
    {
        return new SellRequest(this);
    }

    /// <summary>Field number for the "ticker" field.</summary>
    public const int TickerFieldNumber = 1;
    private string ticker_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Ticker
    {
        get { return ticker_; }
        set
        {
            ticker_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
        }
    }

    /// <summary>Field number for the "quote" field.</summary>
    public const int QuoteFieldNumber = 2;
    private double quote_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public double Quote
    {
        get { return quote_; }
        set
        {
            quote_ = value;
        }
    }

    /// <summary>Field number for the "quantity" field.</summary>
    public const int QuantityFieldNumber = 3;
    private int quantity_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Quantity
    {
        get { return quantity_; }
        set
        {
            quantity_ = value;
        }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other)
    {
        return Equals(other as SellRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(SellRequest other)
    {
        if (ReferenceEquals(other, null))
        {
            return false;
        }
        if (ReferenceEquals(other, this))
        {
            return true;
        }
        if (Ticker != other.Ticker) return false;
        if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Quote, other.Quote)) return false;
        if (Quantity != other.Quantity) return false;
        return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode()
    {
        int hash = 1;
        if (Ticker.Length != 0) hash ^= Ticker.GetHashCode();
        if (Quote != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Quote);
        if (Quantity != 0) hash ^= Quantity.GetHashCode();
        if (_unknownFields != null)
        {
            hash ^= _unknownFields.GetHashCode();
        }
        return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString()
    {
        return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output)
    {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        output.WriteRawMessage(this);
#else
      if (Ticker.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Ticker);
      }
      if (Quote != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(Quote);
      }
      if (Quantity != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Quantity);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
#endif
    }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output)
    {
        if (Ticker.Length != 0)
        {
            output.WriteRawTag(10);
            output.WriteString(Ticker);
        }
        if (Quote != 0D)
        {
            output.WriteRawTag(17);
            output.WriteDouble(Quote);
        }
        if (Quantity != 0)
        {
            output.WriteRawTag(24);
            output.WriteInt32(Quantity);
        }
        if (_unknownFields != null)
        {
            _unknownFields.WriteTo(ref output);
        }
    }
#endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize()
    {
        int size = 0;
        if (Ticker.Length != 0)
        {
            size += 1 + pb::CodedOutputStream.ComputeStringSize(Ticker);
        }
        if (Quote != 0D)
        {
            size += 1 + 8;
        }
        if (Quantity != 0)
        {
            size += 1 + pb::CodedOutputStream.ComputeInt32Size(Quantity);
        }
        if (_unknownFields != null)
        {
            size += _unknownFields.CalculateSize();
        }
        return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(SellRequest other)
    {
        if (other == null)
        {
            return;
        }
        if (other.Ticker.Length != 0)
        {
            Ticker = other.Ticker;
        }
        if (other.Quote != 0D)
        {
            Quote = other.Quote;
        }
        if (other.Quantity != 0)
        {
            Quantity = other.Quantity;
        }
        _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input)
    {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        input.ReadRawMessage(this);
#else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Ticker = input.ReadString();
            break;
          }
          case 17: {
            Quote = input.ReadDouble();
            break;
          }
          case 24: {
            Quantity = input.ReadInt32();
            break;
          }
        }
      }
#endif
    }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input)
    {
        uint tag;
        while ((tag = input.ReadTag()) != 0)
        {
            switch (tag)
            {
                default:
                    _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
                    break;
                case 10:
                    {
                        Ticker = input.ReadString();
                        break;
                    }
                case 17:
                    {
                        Quote = input.ReadDouble();
                        break;
                    }
                case 24:
                    {
                        Quantity = input.ReadInt32();
                        break;
                    }
            }
        }
    }
#endif

}

public sealed partial class TransactionReply : pb::IMessage<TransactionReply>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
    private static readonly pb::MessageParser<TransactionReply> _parser = new pb::MessageParser<TransactionReply>(() => new TransactionReply());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<TransactionReply> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor
    {
        get { return global::RealtimeDataSystem.Maui.Grpc.StockReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor
    {
        get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TransactionReply()
    {
        OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TransactionReply(TransactionReply other) : this()
    {
        ticker_ = other.ticker_;
        quantity_ = other.quantity_;
        transactionConfirmed_ = other.transactionConfirmed_;
        price_ = other.price_;
        _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TransactionReply Clone()
    {
        return new TransactionReply(this);
    }

    /// <summary>Field number for the "ticker" field.</summary>
    public const int TickerFieldNumber = 1;
    private string ticker_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Ticker
    {
        get { return ticker_; }
        set
        {
            ticker_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
        }
    }

    /// <summary>Field number for the "quantity" field.</summary>
    public const int QuantityFieldNumber = 2;
    private int quantity_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Quantity
    {
        get { return quantity_; }
        set
        {
            quantity_ = value;
        }
    }

    /// <summary>Field number for the "transaction_confirmed" field.</summary>
    public const int TransactionConfirmedFieldNumber = 3;
    private bool transactionConfirmed_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool TransactionConfirmed
    {
        get { return transactionConfirmed_; }
        set
        {
            transactionConfirmed_ = value;
        }
    }

    /// <summary>Field number for the "price" field.</summary>
    public const int PriceFieldNumber = 4;
    private double price_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public double Price
    {
        get { return price_; }
        set
        {
            price_ = value;
        }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other)
    {
        return Equals(other as TransactionReply);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(TransactionReply other)
    {
        if (ReferenceEquals(other, null))
        {
            return false;
        }
        if (ReferenceEquals(other, this))
        {
            return true;
        }
        if (Ticker != other.Ticker) return false;
        if (Quantity != other.Quantity) return false;
        if (TransactionConfirmed != other.TransactionConfirmed) return false;
        if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Price, other.Price)) return false;
        return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode()
    {
        int hash = 1;
        if (Ticker.Length != 0) hash ^= Ticker.GetHashCode();
        if (Quantity != 0) hash ^= Quantity.GetHashCode();
        if (TransactionConfirmed != false) hash ^= TransactionConfirmed.GetHashCode();
        if (Price != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Price);
        if (_unknownFields != null)
        {
            hash ^= _unknownFields.GetHashCode();
        }
        return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString()
    {
        return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output)
    {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        output.WriteRawMessage(this);
#else
      if (Ticker.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Ticker);
      }
      if (Quantity != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Quantity);
      }
      if (TransactionConfirmed != false) {
        output.WriteRawTag(24);
        output.WriteBool(TransactionConfirmed);
      }
      if (Price != 0D) {
        output.WriteRawTag(33);
        output.WriteDouble(Price);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
#endif
    }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output)
    {
        if (Ticker.Length != 0)
        {
            output.WriteRawTag(10);
            output.WriteString(Ticker);
        }
        if (Quantity != 0)
        {
            output.WriteRawTag(16);
            output.WriteInt32(Quantity);
        }
        if (TransactionConfirmed != false)
        {
            output.WriteRawTag(24);
            output.WriteBool(TransactionConfirmed);
        }
        if (Price != 0D)
        {
            output.WriteRawTag(33);
            output.WriteDouble(Price);
        }
        if (_unknownFields != null)
        {
            _unknownFields.WriteTo(ref output);
        }
    }
#endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize()
    {
        int size = 0;
        if (Ticker.Length != 0)
        {
            size += 1 + pb::CodedOutputStream.ComputeStringSize(Ticker);
        }
        if (Quantity != 0)
        {
            size += 1 + pb::CodedOutputStream.ComputeInt32Size(Quantity);
        }
        if (TransactionConfirmed != false)
        {
            size += 1 + 1;
        }
        if (Price != 0D)
        {
            size += 1 + 8;
        }
        if (_unknownFields != null)
        {
            size += _unknownFields.CalculateSize();
        }
        return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(TransactionReply other)
    {
        if (other == null)
        {
            return;
        }
        if (other.Ticker.Length != 0)
        {
            Ticker = other.Ticker;
        }
        if (other.Quantity != 0)
        {
            Quantity = other.Quantity;
        }
        if (other.TransactionConfirmed != false)
        {
            TransactionConfirmed = other.TransactionConfirmed;
        }
        if (other.Price != 0D)
        {
            Price = other.Price;
        }
        _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input)
    {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        input.ReadRawMessage(this);
#else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Ticker = input.ReadString();
            break;
          }
          case 16: {
            Quantity = input.ReadInt32();
            break;
          }
          case 24: {
            TransactionConfirmed = input.ReadBool();
            break;
          }
          case 33: {
            Price = input.ReadDouble();
            break;
          }
        }
      }
#endif
    }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input)
    {
        uint tag;
        while ((tag = input.ReadTag()) != 0)
        {
            switch (tag)
            {
                default:
                    _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
                    break;
                case 10:
                    {
                        Ticker = input.ReadString();
                        break;
                    }
                case 16:
                    {
                        Quantity = input.ReadInt32();
                        break;
                    }
                case 24:
                    {
                        TransactionConfirmed = input.ReadBool();
                        break;
                    }
                case 33:
                    {
                        Price = input.ReadDouble();
                        break;
                    }
            }
        }
    }
#endif

}